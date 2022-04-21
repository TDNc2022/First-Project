using Nebby.UnityUtils;
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
                SpawnChip(droppableChips.GetRandomElement(), deadBody.transform, new Vector3(Random.Range(0, 2), 4, Random.Range(0, 2)));
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