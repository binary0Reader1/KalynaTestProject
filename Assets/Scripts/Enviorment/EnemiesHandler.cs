using Enemies;
using Sugar;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Enviorment
{
    public class EnemiesHandler : MonoBehaviour
    {
        public Enemy[] Enemies { get; private set; }

        private int _deadEnemiesCount = 0;

        private void Start()
        {
            Enemies = GetComponentsInChildren<Enemy>();

            if (Enemies.Length == 0) throw new Exception(GetType().Name + " " + StringConstants.ObjectIsNotInitializedExcpetionTitle);

            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].OnDestruct += EnemyDied;
            }
        }

        private async void EnemyDied()
        {
            _deadEnemiesCount++;

            /*Debug.Log("Dead enemies: " + _deadEnemiesCount + " EnemiesCount: " + Enemies.Length);*/

            if (_deadEnemiesCount == Enemies.Length) 
            {
                await Task.Delay(1000);
                FindObjectOfType<LevelManagement>().SetLevelStatus(GameStatusType.Win);
            } 
        }
    }
}