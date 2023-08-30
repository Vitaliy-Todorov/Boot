using System;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public class EntityData
    {
        [SerializeField]
        private EEntityType _entityType;
        [SerializeField]
        private GameObject _prefab;
        public float MaxHealth = 1;
        public float Damage = 0;
        public float Speed = 3;

        public EEntityType EntityType => _entityType;
        public GameObject Prefab => _prefab;
    }
}