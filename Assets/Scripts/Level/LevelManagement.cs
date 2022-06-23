using Level.Objects;
using Sugar;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelManagement : MonoBehaviour
    {
        public LevelConfig CurrentLevelConfig { get; private set; }
        public bool IsLevelCompleted { get; private set; } = false;

        [SerializeField] private RequiredLevelObject[] _requiredLevelObjects;
        [SerializeField] private OptionalLevelObject[] _optionalLevelObject;

        private void Awake()
        {
            InitializeLevel();

            _requiredLevelObjects = (from i in _requiredLevelObjects
                                     orderby i.InitializeOrder descending
                                     select i).ToArray();

            _optionalLevelObject = (from i in _optionalLevelObject
                                    orderby i.InitializeOrder descending
                                    select i).ToArray();


            CollectionOperations.CompleteObjectCollectionActions((LevelObject levelObject) => levelObject.Initialize(this), _requiredLevelObjects);
            CollectionOperations.CompleteObjectCollectionActions((LevelObject levelObject) => levelObject.Initialize(this), _optionalLevelObject);
        }

        public void EndLevel(bool isLevelCompleted)
        {
            IsLevelCompleted = isLevelCompleted;

            CollectionOperations.CompleteObjectCollectionActions((LevelObject levelObject) => levelObject.OnLevelEnded(), _requiredLevelObjects);
            CollectionOperations.CompleteObjectCollectionActions((LevelObject levelObject) => levelObject.OnLevelEnded(), _optionalLevelObject);
        }

        /* WARNING: EXTREMELY CRUNCH ZONE!!!*/
        private static int Level;
        private static bool IsRestarted;

        public static void NextLevel()
        {
            SceneManager.LoadScene(1);
        }
        public static void RestartLevel()
        {
            IsRestarted = true;
            SceneManager.LoadScene(1);
        }

        private void InitializeLevel()
        {
            if (!IsRestarted)
            {
                Level++;
            }

            CurrentLevelConfig = Resources.Load<LevelConfig>("LevelConfigs/LevelConfig" + Convert.ToString(Level));

            if (CurrentLevelConfig == null) Level = 1;

            CurrentLevelConfig = Resources.Load<LevelConfig>("LevelConfigs/LevelConfig" + Convert.ToString(Level));
        }
    }
}