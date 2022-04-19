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

        public ChipInventory ChipInventory { get; private set; }

        [HideInInspector]
        public bool statsDirty;
        void Start()
        {
            CalculateStats();
        }

        private void CalculateStats()
        {
            float moveSpeed = baseMovementSpeed;
            float health = baseMaxHealth;
            float damage = baseDamage;
            float atkSpeed = baseAttackSpeed;

            foreach(ChipDefinition chipDef in ChipInventory.chips)
            {
                moveSpeed = chipDef.movementSpeedModifier.GetModifiedStat(moveSpeed);
                health = chipDef.hpModifier.GetModifiedStat(health);
                damage = chipDef.damageModifier.GetModifiedStat(damage);
                atkSpeed = chipDef.attackSpeedModifier.GetModifiedStat(atkSpeed);
            }

            MovementSpeed = moveSpeed;
            MaxHealth = health;
            Damage = damage;
            AttackSpeed = atkSpeed;
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
