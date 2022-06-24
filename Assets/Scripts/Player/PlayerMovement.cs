using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float MovementSpeed => _movementSpeed;

        [SerializeField] private DynamicJoystick _dynamicJoystick;
        [SerializeField] private float _movementSpeed = 5;

        private Rigidbody _rigidbody;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            _rigidbody.AddForce(new Vector3(_dynamicJoystick.Direction.x, 0, _dynamicJoystick.Direction.y) * _movementSpeed);
        }
    }
}