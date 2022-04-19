using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FirstProject
{
    public class ProjectileSpawner : MonoBehaviour
    {
        public GameObject spawnPrefab;
        public float count = 0f;
        public bool startShoot;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(startShoot == true)
            {
                count += Time.deltaTime;

                if (count >= 2f)
                {
                    Instantiate(spawnPrefab, transform.position, transform.rotation);
                    count = 0f;
                }
            }
            else
            {
                count = 0f;
            }
        }
    }
}
