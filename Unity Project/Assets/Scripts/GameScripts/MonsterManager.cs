using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class MonsterManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        GameObject freshEnemy;
        public Vector3 spTarget;

        public float timer;
        // Start is called before the first frame update
        void Start()
        {
            timer = 1;
            spTarget = PlayerController.Instance.transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            Timer();
        }
        public void Spawn(){
            
            freshEnemy = Instantiate(enemyPrefab,transform.position,transform.rotation);
        }
        public void Timer(){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Spawn();
                timer = 10;
            }
        }
    }
}
