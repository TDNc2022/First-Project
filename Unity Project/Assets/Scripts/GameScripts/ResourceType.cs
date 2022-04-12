using System;

namespace FirstProject
{
    [Flags]
    public enum ResourceType : uint
    { 
        None = 0U,
        Scrap = 1U,
        IntactCircuit = 2U,
        Money = 4U
    }
}