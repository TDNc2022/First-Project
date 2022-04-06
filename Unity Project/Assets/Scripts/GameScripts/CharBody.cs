using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstProject
{
    public class CharBody : MonoBehaviour
    {
        public float baseMovementSpeed;
        public float baseMaxHealth;
        public float baseDamage;
        public float baseAttackSpeed;

        public float MovementSpeed { get; private set; }
        public float MaxHealth { get; private set; }
        public float Damage { get; private set; }
        public float AttackSpeed { get; private set; }
        [HideInInspector]
        public bool statsDirty;
        void Start()
        {
            CalculateStats();
        }

        private void CalculateStats()
        {
            MovementSpeed = baseMovementSpeed;
            MaxHealth = baseMaxHealth;
            Damage = baseDamage;
            AttackSpeed = baseAttackSpeed;
        }
        // Update is called once per frame
        void Update()
        {
            if (statsDirty)
            {
                statsDirty = false;
                CalculateStats();
            }
        }
    }
}
