using DG.Tweening;
using Level;
using Level.Objects;
using System.Threading.Tasks;
using UnityEngine;

namespace Canvas
{
    public class LoseMenu : RequiredLevelObject
    {
        public override int InitializeOrder { get; protected set; } = 0;

        private CanvasGroup _canvasGroup;
        private TransitionBackground _transitionBackground;
        private float _transitionDurationInSeconds = 1;
        private LevelManagement _levelManagement;

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {
            _levelManagement = levelManagement;

            _canvasGroup = GetComponent<CanvasGroup>();
            _transitionBackground = FindObjectOfType<TransitionBackground>();

            gameObject.SetActive(false);
            _canvasGroup.alpha = 0;
        }

        protected async override void OnLevelEndedInstuction()
        {
            if (_levelManagement.IsLevelCompleted) return;

            await Task.Delay((int)(_transitionBackground.TransitionDurationInSeconds * 1000));
            gameObject.SetActive(true);
            DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 1, _transitionDurationInSeconds);
        }

        /* WARNING: EXTREMELY CRUNCH ZONE!!!*/
        public void RestartLevelButtonAction()
        {
            LevelManagement.RestartLevel();
        }
    }
}