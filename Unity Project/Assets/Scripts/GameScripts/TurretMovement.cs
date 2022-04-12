using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class TurretMovement : MonoBehaviour
    {
        public Transform target;

        public ProjectileSpawner projectileSpawner;
        public Transform rotatingObj; 

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

            target = other.transform;

            if (other.tag == "Enemy")
            {
                Vector3 Mira = target.transform.position - transform.position;
                Debug.DrawRay(rotatingObj.position, Mira, Color.blue);
                rotatingObj.LookAt(other.transform, Vector3.up);
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
