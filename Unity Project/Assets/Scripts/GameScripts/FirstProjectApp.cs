using UnityEngine;
using System;

namespace FirstProject
{
    public class FirstProjectApp : MonoBehaviour
    {
        public static Action OnUpdate;
        public static Action OnFixedUpdate;
        public static Action OnLateUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }
}