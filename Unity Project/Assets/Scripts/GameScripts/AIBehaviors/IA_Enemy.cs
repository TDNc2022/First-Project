using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject
{
    public class IA_Enemy : MonoBehaviour
    {
        public Transform target;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        }
        private void FixedUpdate() {
            EnemyRotation();
            EnemyMovement();
        }
        void EnemyMovement(){
            transform.Translate(Vector3.forward * Time.fixedDeltaTime);
        }
        void EnemyRotation(){
            transform.LookAt(target,Vector3.up);
        }
    }
}