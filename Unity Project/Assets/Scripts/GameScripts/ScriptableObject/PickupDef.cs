using System.Collections;
using UnityEngine;

namespace FirstProject
{
    public class PickupDef : ScriptableObject
    {
        public GameObject pickupPrefab;
        public ResourceType resourceType;
        public float resourceValue;
    }
}