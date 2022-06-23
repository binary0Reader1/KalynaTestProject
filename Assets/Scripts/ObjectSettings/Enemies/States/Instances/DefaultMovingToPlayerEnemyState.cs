using FactoryObjects.Enemies;
using ObjectSettings.General;
using Player;
using UnityEngine;

namespace ObjectSettings.Enemies.States.Instances
{
    public class DefaultMovingToPlayerEnemyState : EnemyState, IMoveable, IDamageable
    {
        public float Speed { get; set; }
        public float Damage { get; set; }

        private Vector3 Direction => _player.transform.position - _enemyRigidbody.transform.position;

        private PlayerManagement _player;
        private Rigidbody _playerRigidbody;
        private Rigidbody _enemyRigidbody;

        public DefaultMovingToPlayerEnemyState(Enemy attachedEnemy, IEnemyStateSwitcher attachedEnemyStateSwitcher, PlayerManagement player, Rigidbody enemyRigidbody, float speed, float damage) : base(attachedEnemy, attachedEnemyStateSwitcher)
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
            Move();
        }

        public override void ExitAction()
        {
            _attachedEnemy.OnCollision -= BeatPlayer;
        }

        public void Move()
        {
            Quaternion currentQuaternion = Quaternion.LookRotation(_player.transform.position - _attachedEnemy.transform.position);
            currentQuaternion.z = 0;
            currentQuaternion.x = 0;

            _attachedEnemy.transform.rotation = currentQuaternion;
            _enemyRigidbody.MovePosition(_enemyRigidbody.position + _attachedEnemy.transform.forward * Speed * Time.deltaTime);
        }

        private void BeatPlayer(Collision collision)
        {
            if (collision?.body?.GetComponent<PlayerManagement>() != null)
            {
                _enemyRigidbody.AddForce(-Direction * Speed, ForceMode.Impulse);

                _playerRigidbody.AddForce(Direction * Speed, ForceMode.Impulse);

                DoDamage();
            }
        }

        public void DoDamage()
        {
            _player.ChangeHealth(-Damage);
        }
    }
}