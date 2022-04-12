using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class GlobalEventManager : SingletonBehaviour<GlobalEventManager>
    {
        public Action onBodyDeath;

        public void OnBodyDeath(CharBody slainBody)
        {
            onBodyDeath?.Invoke();
        }
    }
}
