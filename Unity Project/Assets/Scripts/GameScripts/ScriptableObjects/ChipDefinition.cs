using Nebby.UnityUtils.Serialization;
using System;
using UnityEngine;

namespace FirstProject
{
    [CreateAssetMenu(fileName = "New ChipDefinition", menuName = "FirstProject/ChipDefinition")]
    public class ChipDefinition : ScriptableObject
    {
        public string chipName;
        public string chipDescription;
        public int cost;
        public GameObject displayPrefab;

        [Header("Stat Increases")]
        public StatModifier hpModifier;
        public StatModifier damageModifier;
        public StatModifier attackSpeedModifier;
        public StatModifier movementSpeedModifier;
    }
}