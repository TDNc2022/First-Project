using UnityEngine;
using UnityEngine.InputSystem;

namespace FirstProject
{
    [RequireComponent(typeof(CharBody))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : SingletonBehaviour<PlayerController>
    {   
        public CharBody CharBody { get; private set; }

        public CharacterController characterController;
        public float rotationSmoothness;
        private float _smoothVelocity;
        public float yVelocity;
        private float currentYVelocity;
        private Vector3 movementVector;

        private void Start()
        {
            CharBody = GetComponent<CharBody>();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            float targetAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothVelocity, rotationSmoothness);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            if (characterController.isGrounded)
            {
                yVelocity = 0;
            }
            else
                yVelocity -= FirstProjectApp.Gravity * Time.deltaTime;

            movementVector.y = Mathf.SmoothDamp(movementVector.y, yVelocity, ref currentYVelocity, FirstProjectApp.Gravity, -10);
            characterController.Move(movementVector * CharBody.MovementSpeed * Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext cbContext)
        {
            Vector2 vector = cbContext.ReadValue<Vector2>();
            movementVector = new Vector3(vector.x, 0, vector.y).normalized;
        }
    }
}