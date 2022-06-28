using ObjectSettings.General;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerManagement : MonoBehaviour, IHealthChangeable, IMoveable, IDestructable
    {
        public Vector2 Direction { 
            get
            {
                return new Vector2(_direction.x, _direction.z);
            }
            set
            {
                _direction = new Vector3(value.x, 0, value.y);
            }
        }

        public float Speed { get => _speed; set => _speed = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public Action OnHealthChanged { get; set; }
        public Action OnDestruct { get; set; }
        public float Health { get; set; }

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _speed = 5;

        private bool _canMove = true;
        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private bool _isDestroyed = false;

        

        private void Start()
        {
            Health = MaxHealth;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_canMove) Move();
        }

        public void Move()
        {
            _rigidbody.AddForce(_direction * _speed);
        }

        public void ChangeHealth(float value)
        {
            Health = Mathf.Clamp(Health + value, 0, MaxHealth);

            OnHealthChanged?.Invoke();

            if (Health == 0) Destruct();
        }

        public async void Destruct()
        {
            if (_isDestroyed) return;

            _isDestroyed = true;

            OnDestruct?.Invoke();
            _canMove = false;
            _rigidbody.freezeRotation = false;

            await Task.Delay(1000);

            FindObjectOfType<LevelManagement>().SetLevelStatus(GameStatusType.Lose);            
        }
    }
}