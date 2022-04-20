using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject
{
    [RequireComponent(typeof(CharBody))]
    public class EnemyStats : MonoBehaviour
    {
        public int hp;
        public int atk;
        public int atkSpeed;
        public int moveSpeed;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Die()
        {

        }
         void EnemyMovement(){
            transform.Translate(Vector3.forward * Time.fixedDeltaTime);
        }
    }
}
