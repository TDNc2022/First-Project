using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject
{
        public class IA_Enemy : MonoBehaviour
    {
        public Transform target;
        public CharBody EnemyCharBody {get; private set;}
        private void Awake() {
            EnemyCharBody = GetComponent<CharBody>();
        }
        private void FixedUpdate() {
            EnemyRotation();
            EnemyMovement();
        }
        void EnemyMovement(){
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * EnemyCharBody.MovementSpeed);
        }
        void EnemyRotation(){
            transform.LookAt(target,Vector3.up);
        }
    }
}