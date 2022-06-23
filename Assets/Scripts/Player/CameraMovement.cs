using UnityEngine;

namespace Player
{
    public class CameraMovement : MonoBehaviour
    {

        [SerializeField] private Transform _target;
        [SerializeField] float _movementSpeed = 1;

        private Rigidbody _rigidbody;
        private Vector3 Direction => _target.position - transform.position;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 newPosition = Direction;
            newPosition.y = 0;

            _rigidbody.AddForce(newPosition * _movementSpeed);
        }
    }
}