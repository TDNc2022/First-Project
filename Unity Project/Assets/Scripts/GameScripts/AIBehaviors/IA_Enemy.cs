using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FirstProject
{
        public class IA_Enemy : MonoBehaviour
    {

        public Transform target;
        public CharBody EnemyCharBody {get; private set;}
        private NavMeshAgent NavA;
        private void Awake() {
            EnemyCharBody = GetComponent<CharBody>();
            NavA = GetComponent<NavMeshAgent>();
        }
        private void FixedUpdate() {
            EnemyMovement();

            if(NavA.velocity.magnitude < 0.15f && Vector3.Distance(transform.position, target.position) <= 2.1f) 
            {
                EnemyAttack();
                //Ventana de Ataque
            }
        }
        void EnemyMovement(){
            NavA.speed = EnemyCharBody.MovementSpeed;
            NavA.destination = target.position;
            NavA.stoppingDistance = 2f;
        }
        void EnemyRotation(){
            transform.LookAt(target,Vector3.up);
        }
        void EnemyAttack(){

        }

    }
}