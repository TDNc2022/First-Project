using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Torreta : MonoBehaviour
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
    private void OnTriggerStay(Collider other)
    {
        Vector3 Mira = target.position - transform.position;
        Debug.DrawRay(transform.position, Mira, Color.blue);
        if (other.tag == "Enemigo")
        {
            Quaternion rotacionTarget = Quaternion.LookRotation(Mira);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionTarget, Time.deltaTime);
        }
    }
}
