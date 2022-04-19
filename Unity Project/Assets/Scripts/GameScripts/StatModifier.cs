using System;

namespace FirstProject
{
    [Serializable]
    public struct StatModifier
    {
        public float amount;
        public StatIncreaseType statIncreaseType;

        public float GetModifiedStat(float stat)
        {
            switch(statIncreaseType)
            {
                case StatIncreaseType.Additive:
                    return stat + amount;
                case StatIncreaseType.Multiplicative:
                    return stat * amount;
            }
            return stat;
        }
    }

    public enum StatIncreaseType
    {
        Multiplicative,
        Additive
    }
}