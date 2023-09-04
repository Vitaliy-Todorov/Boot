using System;
using Data;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Entities
{
    public class Damage : MonoBehaviour
    {
        private float DamageValue => _entityData.Damage;
        private EntityData _entityData;

        public void Init(EntityData entityData)
        {
            _entityData = entityData;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.gameObject.GetComponentInParent<Health>();
            if(health != null)
            {
                health.CauseDamage(DamageValue);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Health health = other.GetComponentInParent<Health>();
            if(health != null)
            {
                health.CauseDamage(DamageValue);
            }
        }
    }
}