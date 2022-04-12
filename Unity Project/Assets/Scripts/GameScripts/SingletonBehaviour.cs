using System.Collections;
using UnityEngine;

namespace FirstProject
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
                throw new System.Exception($"An instance of the singleton {typeof(T).Name} already exists");
            }
            else
            {
                Instance = (T)this;
            }
        }
    }
}