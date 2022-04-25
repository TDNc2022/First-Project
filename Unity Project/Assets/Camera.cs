using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject{
    public class Camera : MonoBehaviour
    {
        private Transform playerPos;
        private Vector3 desiredPos;
        // Start is called before the first frame update
        void Update()
        {
            playerPos = PlayerController.Instance.transform;

            desiredPos = new Vector3(playerPos.position.x,(playerPos.position.y -.5f), playerPos.position.z);
            this.transform.position = desiredPos;
        }
    }
}
