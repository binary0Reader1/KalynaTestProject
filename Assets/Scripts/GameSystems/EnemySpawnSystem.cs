using Enviorment.EnemySpawn;
using Factories;
using FactoryObjects.Enemies;
using Level;
using Level.Objects;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems
{
    public class EnemySpawnSystem : RequiredLevelObject
    {
        public override int InitializeOrder { get; protected set; } = 100;

        [SerializeField] private EnemyFactory _enemyFactory;

        private EnemySpawnPoint[] _enemySpawnPoints;
        private EnemyType[] _testEnemyTypes = new EnemyType[]
        {
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy
        };
        private int _testMillisecondsBetweenSpawning = 2000;
        private bool _isLevelEnded;

        public void Initialize(EnemyType[] enemyTypes, int millisecondsBetweenSpawning)
        {

        }

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {
            SpawnProcess(levelManagement.CurrentLevelConfig.LevelEnemies, _testMillisecondsBetweenSpawning);
        }

        private async void SpawnProcess(EnemyType[] enemyTypes, int millisecondsBetweenSpawning)
        {
            for (int i = 0; i < enemyTypes.Length; i++)
            {
                if (_isLevelEnded) break;
                _enemyFactory.CreateObject(_enemyFactory.GetObject(enemyTypes[i]));
                await Task.Delay(millisecondsBetweenSpawning);
            }
        }

        protected override void OnLevelEndedInstuction()
        {
            _isLevelEnded = true;
        }
    }
}