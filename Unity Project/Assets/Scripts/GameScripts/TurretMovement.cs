using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class TurretMovement : MonoBehaviour
    {
        public Transform target;

        public ProjectileSpawner projectileSpawner;

   

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {





      
        }
        private void OnTriggerStay(Collider other)
        {
            Vector3 Mira = target.position - transform.position;
            Debug.DrawRay(transform.position, Mira, Color.blue);

            if (other.tag == "Enemy")
            {

                Quaternion rotacionTarget = Quaternion.LookRotation(Mira);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionTarget, Time.deltaTime);
                projectileSpawner.startShoot = true;
                
            }


        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Enemy")
            {
                projectileSpawner.startShoot = false;
            }

        }


    }
}
