using ObjectSettings.General;
using UnityEngine;

namespace Player
{
    public class CameraMovement : MonoBehaviour, IMoveable
    {
        public float Speed { get => _speed; set => _speed = value; }
        private Vector3 Direction => _target.position - transform.position;

        [SerializeField] private Transform _target;
        [SerializeField] float _speed = 1;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            Vector3 newPosition = Direction;
            newPosition.y = 0;

            _rigidbody.AddForce(newPosition * _speed);
        }
    }
}