using Level;
using ObjectSettings.General;
using System;
using UnityEngine;

namespace Player
{
    public class PlayerManagement : MonoBehaviour, IHealthChangeable, IMoveable, IDestructable
    {
        public float Speed { get => _speed; set => _speed = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

        public Action OnHealthChanged { get; set; }
        public Action OnDestruct { get; set; }
        public float Health { get; set; }

        [SerializeField] private DynamicJoystick _dynamicJoystick;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _speed = 5;

        private bool _canMove = true;
        private Rigidbody _rigidbody;
        private LevelManagement _levelManagement;

        public void Move()
        {
            _rigidbody.AddForce(new Vector3(_dynamicJoystick.Direction.x, 0, _dynamicJoystick.Direction.y) * _speed);
        }

        private void Start()
        {
            Health = MaxHealth;
            _rigidbody = GetComponent<Rigidbody>();
            _levelManagement = FindObjectOfType<LevelManagement>();
        }

        private void Update()
        {
            if (_canMove) Move();
        }

        public void ChangeHealth(float value)
        {
            Health = Mathf.Clamp(Health + value, 0, MaxHealth);

            OnHealthChanged?.Invoke();

            if (Health == 0) Destruct();
        }

        public void Destruct()
        {
            OnDestruct?.Invoke();

            _dynamicJoystick.gameObject.SetActive(false);

            _levelManagement.EndLevel(false);
            _canMove = false;
            _rigidbody.freezeRotation = false;
        }
    }
}