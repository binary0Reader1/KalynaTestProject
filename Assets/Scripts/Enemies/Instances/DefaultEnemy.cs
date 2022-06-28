using ObjectSettings.Enemies.States;
using ObjectSettings.Enemies.States.Instances;
using Player;
using UnityEngine;

namespace Enemies.Instances
{
    public class DefaultEnemy : Enemy
    {
        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 2;

        [SerializeField] private float _damage = 10;

        protected override EnemyState[] InitializeStatesInstruction()
        {
            PlayerManagement player = FindObjectOfType<PlayerManagement>();
            return new EnemyState[]
            {
            new DefaultMovingToPlayerEnemyState(this,this,player,RigidbodyReference,Random.Range(_minSpeed,_maxSpeed),_damage)
            };
        }
    }
}