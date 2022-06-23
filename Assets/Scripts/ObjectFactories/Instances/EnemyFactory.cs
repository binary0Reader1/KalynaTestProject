using Enviorment.EnemySpawn;
using FactoryObjects.Enemies;
using Level;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public class EnemyFactory : ObjectFactory<Enemy, EnemyType>
    {
        public override int InitializeOrder { get; protected set; } = 100;

        [SerializeField] private EnemySpawnPointsHandler _enemySpawnPointsHandler;

        private List<Enemy> _createdEnemies = new List<Enemy>();
        private int _enemySpawnPointNumber = 0;
        private LevelManagement _levelManagement;
        private int _deadEnemiesCount;

        public override Enemy GetObject(EnemyType enemyType)
        {
            if (enemyType == EnemyType.DefaultEnemy)
            {
                return objectsHandler[0];
            }

            if (enemyType == EnemyType.FastEnemy)
            {
                return objectsHandler[1];
            }

            if (enemyType == EnemyType.BigEnemy)
            {
                return objectsHandler[2];
            }

            throw new Exception("Invalid object type");
        }

        public override void CreateObject(Enemy objectInstance)
        {
            Transform spawnPointTransform = _enemySpawnPointsHandler.SpawnPoints[_enemySpawnPointNumber].transform;
            Enemy enemy = Instantiate(objectInstance, spawnPointTransform.position, Quaternion.identity);

            enemy.OnDestruct += EnemyDied;
            _createdEnemies.Add(enemy);

            _enemySpawnPointNumber++;

            if (_enemySpawnPointNumber >= _enemySpawnPointsHandler.SpawnPoints.Length) _enemySpawnPointNumber = 0;
        }

        public void EnemyDied()
        {
            _deadEnemiesCount++;

            if (_deadEnemiesCount >= _levelManagement.CurrentLevelConfig.LevelEnemies.Length) _levelManagement.EndLevel(true);
        }

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {
            _levelManagement = levelManagement;
        }

        protected override void OnLevelEndedInstuction()
        {
            for (int i = 0; i < _createdEnemies.Count; i++)
            {
                _createdEnemies[i].OnDestruct -= EnemyDied;
            }
        }
    }
}