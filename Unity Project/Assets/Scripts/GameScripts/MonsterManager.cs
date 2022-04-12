using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class MonsterManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        GameObject freshEnemy;
        public Transform playerPos;
        public float timer;
        // Start is called before the first frame update
        void Start()
        {
            timer = 1;
        }
        // Update is called once per frame
        void Update()
        {
            LockTarget();
            Timer();
        }
        public void Spawn(){
            
            freshEnemy = Instantiate(enemyPrefab,transform.position,transform.rotation);
            freshEnemy.GetComponent<IA_Enemy>().target = playerPos;
        }
        public void Timer(){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Spawn();
                timer = 10;
            }
        }
        public void LockTarget(){
            playerPos = PlayerController.Instance.transform; //a
        }
    }
}
