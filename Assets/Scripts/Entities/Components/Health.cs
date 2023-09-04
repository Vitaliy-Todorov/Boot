using System.Collections;
using System.Collections.Generic;
using Data;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Entities
{
    public class Health : MonoBehaviour
    {
        private EntityData _entityData;
        private float _currentHealth;

        public void Init(EntityData entityData)
        {
            _entityData = entityData;
            _currentHealth = _entityData.MaxHealth;
        }
        public void CauseDamage(float damage)
        {
            _currentHealth -= damage;
            
            if(_currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}