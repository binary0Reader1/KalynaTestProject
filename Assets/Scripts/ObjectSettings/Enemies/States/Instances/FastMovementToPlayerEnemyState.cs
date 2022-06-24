using FactoryObjects.Enemies;
using ObjectSettings.General;
using Player;
using UnityEngine;

namespace ObjectSettings.Enemies.States.Instances
{
    public class FastMovementToPlayerEnemyState : EnemyState, IMoveable, IDamageable
    {
        public float Speed { get; set; }
        public float Damage { get; set; }

        private Vector3 Direction => _player.transform.position - _enemyRigidbody.transform.position;

        private PlayerManagement _player;
        private Rigidbody _playerRigidbody;
        private Rigidbody _enemyRigidbody;

        public FastMovementToPlayerEnemyState(Enemy attachedEnemy, IEnemyStateSwitcher attachedEnemyStateSwitcher, PlayerManagement player, Rigidbody enemyRigidbody, float speed, float damage) : base(attachedEnemy, attachedEnemyStateSwitcher)
        {
            Speed = speed;
            Damage = damage;

            _player = player;
            _enemyRigidbody = enemyRigidbody;
        }

        public override void StartAction()
        {
            _attachedEnemy.OnCollision += BeatPlayer;
            _playerRigidbody = _player.GetComponent<Rigidbody>();
        }

        public override void UpdateAction()
        {

        }

        public override void FixedUpdateAction()
        {
            Move();
        }

        public override void ExitAction()
        {
            _attachedEnemy.OnCollision -= BeatPlayer;
        }

        public void Move()
        {
            Vector3 forceDirection = Direction;
            forceDirection.y = 0;

            _enemyRigidbody.AddForce(forceDirection * Speed);
        }

        private void BeatPlayer(Collision collision)
        {
            if (collision?.body?.GetComponent<PlayerManagement>() != null)
            {
                _enemyRigidbody.AddForce(-Direction * Speed/2, ForceMode.Impulse);

                _playerRigidbody.AddForce(Direction * Speed/2, ForceMode.Impulse);

                DoDamage();
            }
        }

        public void DoDamage()
        {
            _player.ChangeHealth(-Damage);
        }
    }
}