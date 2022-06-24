using ObjectSettings.Enemies.States;
using ObjectSettings.Enemies.States.Instances;
using Player;
using UnityEngine;

namespace FactoryObjects.Enemies.Instances
{
    public class FastEnemy : Enemy
    {
        [SerializeField] private float _minSpeed = 4;
        [SerializeField] private float _maxSpeed = 6;

        [SerializeField] private float _damage = 10;

        protected override EnemyState[] InitializeStatesInstruction()
        {
            PlayerManagement player = FindObjectOfType<PlayerManagement>();
            return new EnemyState[]
            {
            new FastMovementToPlayerEnemyState(this,this,player,RigidbodyReference,Random.Range(_minSpeed,_maxSpeed),_damage)
            };
        }
    }
}