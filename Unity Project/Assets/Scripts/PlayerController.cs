using UnityEngine;
using UnityEngine.InputSystem;

namespace FirstProject
{
    [RequireComponent(typeof(CharBody))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {   
        public static PlayerController Instance { get; private set; }
        public CharBody CharBody { get; private set; }

        public CharacterController characterController;
        public float rotationSmoothness;
        private float _smoothVelocity;
        private Vector3 movementVector;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                throw new System.Exception("An instance of this singleton already exists.");
            }
            else
            {
                Instance = this;
            }
        }

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
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            characterController.Move(movementVector * CharBody.MovementSpeed * Time.deltaTime);
        }
        private void OnMove(InputAction.CallbackContext cbContext)
        {
            Vector2 vector = cbContext.ReadValue<Vector2>();
            movementVector = new Vector3(vector.x, 0, vector.y).normalized;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}