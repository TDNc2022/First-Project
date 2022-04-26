﻿using Nebby.UnityUtils;
using Nebby.CSharpUtils;
using UnityEngine;

namespace FirstProject
{
    public class GlobalEventManager : SingletonBehaviour<GlobalEventManager>
    {
        public GameObject GenericPickupPrefab;
        public ChipDefinition[] droppableChips;

        public void OnCharacterDeath(CharBody deadBody)
        {
            if(deadBody.CompareTag("Enemy"))
            {
                if(droppableChips.TryGetRandomElement(out var chipDef))
                {
                    SpawnChip(chipDef, deadBody.transform, new Vector3(Random.Range(0, 2), 4, Random.Range(0, 2)));

                    var currentEnemies = WaveManager.Instance.currentEnemies;
                    var rootGO = deadBody.gameObject.GetRootGameObject();
                    if(currentEnemies.Contains(rootGO))
                    {
                        currentEnemies.Remove(rootGO);
                    }
                }
            }
        }

        public void SpawnChip(ChipDefinition chipToSpawn, Transform location, Vector3 velocity)
        {
            GameObject instance = Instantiate(GenericPickupPrefab, location.position, location.rotation);
            ChipPickup pickup = instance.GetComponent<ChipPickup>();
            Rigidbody rigidBody = instance.GetComponent<Rigidbody>();

            pickup.TiedChip = chipToSpawn;
            rigidBody.AddForce(velocity, ForceMode.VelocityChange);
        }
    }
}