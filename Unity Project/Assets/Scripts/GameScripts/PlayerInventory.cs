using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FirstProject
{
    public class PlayerInventory : MonoBehaviour
    {
        [Serializable]
        public class ChipCount
        {
            public ChipDefinition chip;
            public int count;

            public ChipCount(ChipDefinition def, int num)
            {
                chip = def;
                count = num;
            }
        }

        public List<ChipCount> heldChips = new List<ChipCount>();

        private int GetChipIndex(ChipDefinition chipDef)
        {
            return heldChips.FindIndex(chipCount => chipCount.chip == chipDef);
        }

        public void AddChip(ChipDefinition chipDefinition, int count = 1)
        {
            int index = GetChipIndex(chipDefinition);
            ChipCount chipCount = null;
            if (index == -1)
            {
                chipCount = new ChipCount(chipDefinition, count);
                heldChips.Add(chipCount);
                return;
            }
            chipCount = heldChips[index];
            chipCount.count += count;
        }

        public void RemoveChip(ChipDefinition chipDefinition, int count = 1)
        {
            int index = GetChipIndex(chipDefinition);
            if (index == -1)
            {
                return;
            }
            ChipCount chipCount = heldChips[index];
            chipCount.count -= count;
            if (chipCount.count <= 0)
                heldChips.Remove(chipCount);
        }
    }
}