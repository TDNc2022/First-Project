using UnityEngine;
using System;
using Nebby.UnityUtils;
using UnityEngine.SceneManagement;
using System.Linq;
namespace FirstProject
{
    public class FirstProjectApp : SingletonBehaviour<FirstProjectApp>
    {
        public Difficulty selectedDifficulty;
        public static Action OnUpdate;
        public static Action OnFixedUpdate;
        public static Action OnLateUpdate;
        public const float Gravity = 9.81f;
        private void Awake()
        {
            base.Awake();
            SceneManager.activeSceneChanged += OnSceneLoaded;
        }
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
        void OnSceneLoaded(Scene previus,Scene current)
        {
            GameObject globalEventManager = current.GetRootGameObjects().Where(x => x.GetComponent<WaveManager>()).FirstOrDefault();
            if (globalEventManager)
            {
                WaveManager name = globalEventManager.GetComponent<WaveManager>();
                name.waves = selectedDifficulty.waves;
                name.timeBetweenWaves = selectedDifficulty.timeBetweenWaves;
            }
        }
    }
}