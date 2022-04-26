using System.Collections;
using UnityEngine;
using System.Linq;
using Nebby.CSharpUtils;
using System.Collections.Generic;

namespace FirstProject
{
    public class ChipInventory : MonoBehaviour
    {
        public List<ChipDefinition> chips = new List<ChipDefinition>();
        
        public int maxChipCredits;
        public int CurrentSpentChipCredits { get; private set; }
        public CharBody CharBody { get; private set; }

        public void Awake()
        {
            CharBody = GetComponent<CharBody>();
        }
        public bool AddNewChip(ChipDefinition chip)
        {
            /*if (chips.Contains(chip))
                return false;*/

            int creditsAfterAddition = CurrentSpentChipCredits + chip.cost;
            if (creditsAfterAddition > maxChipCredits)
                return false;

            chips.Add(chip);
            OnChipInventoryChanged();
            return true;
        }

        public void RemoveChip(ChipDefinition chip)
        {
            if (!chips.Contains(chip))
                return;

            chips.Remove(chip);
        }

        private void OnChipInventoryChanged()
        {
            int num = 0;
            foreach(ChipDefinition def in chips)
            {
                num += def.cost;
            }
            CurrentSpentChipCredits = num;
            CharBody.statsDirty = true;
        }

    }
}