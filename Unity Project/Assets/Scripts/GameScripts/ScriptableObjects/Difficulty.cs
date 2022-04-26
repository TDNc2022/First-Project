using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace FirstProject{

    [CreateAssetMenu(fileName = "New Difficulty", menuName = "FirstProject/Difficulty")]
        public class Difficulty : ScriptableObject
    {
        public WaveManager.Wave[] waves = Array.Empty<WaveManager.Wave>();
        public float timeBetweenWaves;
    }
}