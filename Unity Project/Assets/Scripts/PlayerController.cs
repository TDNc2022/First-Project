using UnityEngine;
using UnityEngine.InputSystem;

namespace FirstProject
{
    [RequireComponent(typeof(CharBody))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {   
        public static PlayerController Instance { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public CharBody CharBody { get; private set; }
        private Vector3 movementVector;

        private void Awake()
        {
            if(Instance)
            {
                Debug.LogError($"Cannot have more than 1 instance of {nameof(PlayerController)}");
                Destroy(gameObject);
            }
            Instance = this;
        }

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            CharBody = GetComponent<CharBody>();
        }
        private void FixedUpdate()
        {
            MovePlayer();
        }
        private void MovePlayer()
        {
            //Rigidbody.MovePosition(UnityEngine.Rigidbody.position + movementVector * CharBody.MovementSpeed * Time.fixedDeltaTime);
        }
        private void OnMove(InputAction.CallbackContext cbContext)
        {
            movementVector = cbContext.ReadValue<Vector2>();
        }
    }
}