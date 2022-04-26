using Nebby.UnityUtils;
using System.Collections;
using UnityEngine;

namespace FirstProject
{
    public class ChipPickup : MonoBehaviour
    {
        public ChipDefinition TiedChip
        {
            get
            {
                return _tiedChip;
            }
            set
            {
                if(_tiedChip != value)
                {
                    _tiedChip = value;
                    OnChipChanged();
                }
            }
        }
            
        private ChipDefinition _tiedChip;
        public Transform displayRoot;

        private void OnChipChanged()
        {
            foreach(Transform transform in displayRoot)
            {
                Debug.Log(transform.gameObject.name);
                Destroy(transform.gameObject);
            }
            var instance = Instantiate(TiedChip.displayPrefab, displayRoot);
            instance.transform.position = Vector3.zero;
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject rootObj = collision.gameObject.GetRootGameObject();
            if(rootObj.CompareTag("Player"))
            {
                PlayerController.Instance.PlayerInventory.AddChip(TiedChip);
                Destroy(gameObject.GetRootGameObject());
            }
        }
    }
}