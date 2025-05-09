using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _sensitivity = 1f;
        [SerializeField] private float _maxCameraTilt = 5f;
        [SerializeField] private float _cameraTiltSpeed = 5f;
        [SerializeField] private LayerMask _groundCheckMask;

        [SerializeField] Transform _camera;
        [SerializeField] SphereCollider _groundChecker;
        [SerializeField] BoxCollider _coyoteChecker;
        [SerializeField] BoxCollider _wallChecker;

        [Header("Weapon")]
        [SerializeField] private Weapon _weapon;

        private CharacterController _controller;
        private Transform _transform;

        private InputActions _input;

        private float _yVelocity = 0;
        private float _cameraAngleX;
        private float _cameraAngleZ;

        private void Awake()
        {
            _input = new();
            _controller = GetComponent<CharacterController>();
            _transform = transform;

            _cameraAngleX = _camera.localEulerAngles.x;
            _cameraAngleZ = _camera.localEulerAngles.z;
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Jump.performed += GetJumpImpulse;
            _input.Player.Attack.performed += OnAttack;
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Player.Jump.performed -= GetJumpImpulse;
            _input.Player.Attack.performed -= OnAttack;
        }

        private void FixedUpdate()
        {
            ProcessMovement();
            RotateCamera();
        }

        private void ProcessMovement()
        {
            Vector2 input = _input.Player.Move.ReadValue<Vector2>();
            Vector3 direction = _transform.right * input.x + _transform.forward * input.y;

            _controller.Move(new Vector3(direction.x * _speed, _yVelocity, direction.z * _speed) * Time.fixedDeltaTime);

            if (_controller.isGrounded == false)
            {
                _yVelocity += Physics.gravity.y;
            }
            else
            {
                _yVelocity = -1;
            }

            _cameraAngleZ = Mathf.Lerp(_cameraAngleZ, _maxCameraTilt * -input.x, _cameraTiltSpeed * Time.fixedDeltaTime);
            _camera.localEulerAngles = new Vector3(
                _camera.localEulerAngles.x,
                _camera.localEulerAngles.y,
                _cameraAngleZ);
        }

        private void RotateCamera()
        {
            Vector2 pointerDelta = _input.Player.Look.ReadValue<Vector2>();

            _cameraAngleX = Mathf.Clamp(_cameraAngleX - pointerDelta.y * _sensitivity * Time.fixedDeltaTime, -89, 89);
            _camera.localEulerAngles = new Vector3(
                _cameraAngleX,
                _camera.localEulerAngles.y,
                _camera.localEulerAngles.z);

            _transform.Rotate(Vector3.up * pointerDelta.x * _sensitivity * Time.fixedDeltaTime);
        }

        private void GetJumpImpulse(InputAction.CallbackContext context)
        {
            if (Physics.CheckSphere(_groundChecker.transform.position, _groundChecker.radius, _groundCheckMask)
                || Physics.CheckBox(_coyoteChecker.transform.position, _coyoteChecker.size / 2f, _transform.rotation, _groundCheckMask)
                && Physics.CheckBox(_wallChecker.transform.position, _wallChecker.size / 2f, _transform.rotation, _groundCheckMask) == false)
                _yVelocity = _jumpForce;
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            _weapon.OnAttack(Quaternion.Euler(_camera.eulerAngles.x, _transform.eulerAngles.y, _transform.position.z));
        }
    }
}
