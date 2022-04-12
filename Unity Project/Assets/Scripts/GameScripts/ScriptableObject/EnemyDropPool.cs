using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    [CreateAssetMenu(fileName = "new EnemyDropPool", menuName = "FirstProject/EnemyDropPool")]
    public class EnemyDropPool : ScriptableObject
    {
        [Serializable]
        public struct Category
        {
            public string name;
            public float pickChance;
            public GameObject[] dropPrefabs;
        }

        public Category[] dropCategories;
    }
}