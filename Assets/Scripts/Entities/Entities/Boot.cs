using System;
using Data;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Entities
{
    [RequireComponent (typeof (BootMovement), typeof (Health), typeof (Damage))]
    public class Boot : MonoBehaviour, IEntity
    {
        private string _id;
        [SerializeField]
        private EEntityType _entityType;
        
        private Health _health;
        private Damage _damage;
        private IMovement _movement;

        public string ID => _id;
        public EEntityType EntityType => _entityType;
        public GameObject GameObject => gameObject;

        public Health Health => _health;

        public IMovement Movement => _movement;

        public event Action<string> Destroyed;

        public void Init(GameManager gameManager, EntityData entityData)
        {
            _id = $"Boot_{gameObject.GetInstanceID()}";
            if (_entityType == EEntityType.None)
                _entityType = entityData.EntityType;
            _health = GetComponent<Health>();
            _health.Init(entityData);
            _damage = GetComponent<Damage>();
            _damage.Init(entityData);
            
            _movement = GetComponent<IMovement>();
            _movement.Init(gameManager, entityData);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke(ID);
        }
    }
}