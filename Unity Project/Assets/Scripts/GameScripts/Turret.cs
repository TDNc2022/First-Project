using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nebby.UnityUtils;
using Nebby.CSharpUtils;

namespace FirstProject{
    public class Turret : MonoBehaviour
    {
        private Transform target;
        private CharBody _charBody;
        [Header("Attributes")]
        public float fireRate;
        private float fireCountdown = 0f;
        public float range;

        [Header("Unity Setup Fields")]
        public string enemyTag="Enemy";
        public Transform partToRotate;
        public float turnSpeed = 10f;
        public GameObject bulletPrefab;
        public Transform firePoint;
        void Stats()
        {
            fireRate = _charBody.AttackSpeed;
        }
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, .5f);
            _charBody = GetComponent<CharBody>();
        }
        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance<=range)
            {
                target = nearestEnemy.transform;
            } else
            {
                target = null;
            }
        }
        // Update is called once per frame
        void Update()
        {
            Rotate(target);

            if (target == null)
            {
                return;
            }

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        void Rotate(Transform _target)
        {
            if (_target != null)
            {
                Vector3 dir = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y , 0f);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInventory playerInventory = PlayerController.Instance.PlayerInventory;
                if (playerInventory)
                    TryGiveChip(playerInventory);
            }
        }

        private void TryGiveChip(PlayerInventory pInventory)
        {
            ChipInventory inventory = _charBody.ChipInventory;

            if(inventory)
            {
                if(pInventory.heldChips.TryGetRandomElement(out var chipCount))
                {
                    if(chipCount != null)
                    {
                        ChipDefinition definition = chipCount.chip;
                        if(inventory.AddNewChip(definition))
                        {
                            pInventory.RemoveChip(definition);
                        }
                    }
                }
            }
        }
        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target, _charBody.Damage);
            }
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}