using UnityEngine;
using System;
using Nebby.UnityUtils;

namespace FirstProject
{
    public class FirstProjectApp : SingletonBehaviour<FirstProjectApp>
    {
        public static Action OnUpdate;
        public static Action OnFixedUpdate;
        public static Action OnLateUpdate;
        public const float Gravity = 9.81f;
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