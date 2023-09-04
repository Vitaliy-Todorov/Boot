using System;
using Data;
using Infrastructure;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Health))]
    public class Ball : MonoBehaviour, IEntity
    {
        private string _id;
        [SerializeField]
        private EEntityType _entityType;
        
        private Health _health;

        public string ID => _id;
        public EEntityType EntityType => _entityType;
        public GameObject GameObject => gameObject;

        public Health Health => _health;

        public event Action<string> Destroyed;

        public void Init(GameManager gameManager, EntityData entityData)
        {
            _id = $"Ball_{gameObject.GetInstanceID()}";
            if (_entityType == EEntityType.None)
                _entityType = entityData.EntityType;
            
            _health = GetComponent<Health>();
            _health.Init(entityData);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke(ID);
        }
    }
}