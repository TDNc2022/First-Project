using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Proiyectil : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float count = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count >= 2f)
        {
            Instantiate(spawnPrefab, transform.position, transform.rotation);
            count = 0f;
        }
     

    }
}
