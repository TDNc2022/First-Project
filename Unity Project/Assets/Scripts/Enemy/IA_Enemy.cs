using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject{
public class IA_Enemy : MonoBehaviour
    {
        public Vector3 target;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            target = PlayerController.Instance.transform.position;
        }

    }
}