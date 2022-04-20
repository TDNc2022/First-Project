using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public float damage {get; set;}
        public float speed = 5f;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 5f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        // private void OnTriggerEnter(Collider other)
        // {
        //     if(other.tag == "Enemy")
        //     {
        //         Destroy(this.gameObject);
        //     }
        // }



    }
}