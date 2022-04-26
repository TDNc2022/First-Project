using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject{
    public class Bullet : MonoBehaviour
    {
        private Transform target;
        public float speed = 35f;
        public float damage;
        public void Seek (Transform _target, float _damage)
        {
            target = _target;
            damage = _damage;
        }
        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        void HitTarget()
        {
            CharBody targetCharBody = target.GetComponent<CharBody>();
            targetCharBody.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
