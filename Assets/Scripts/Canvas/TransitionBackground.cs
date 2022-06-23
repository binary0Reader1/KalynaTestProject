using DG.Tweening;
using Level;
using Level.Objects;
using UnityEngine;

namespace Canvas
{
    public class TransitionBackground : OptionalLevelObject
    {
        public float TransitionDurationInSeconds => _transitionDurationInSeconds;
        public override int InitializeOrder { get; protected set; } = 0;

        [SerializeField] private float _transitionDurationInSeconds = 1;

        private CanvasGroup _canvasGroup;

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {
            gameObject.SetActive(true);
            _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.alpha = 1;

            DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 0, _transitionDurationInSeconds);
        }

        protected override void OnLevelEndedInstuction()
        {
            gameObject.SetActive(true);

            _canvasGroup.alpha = 0;

            DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 1, _transitionDurationInSeconds);
        }
    }
}
