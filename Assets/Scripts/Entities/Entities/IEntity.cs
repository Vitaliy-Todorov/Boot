using System;
using Data;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Entities
{
    public interface IEntity
    {
        string ID { get; }
        public EEntityType EntityType { get; }
        GameObject GameObject { get; }
        public Health Health { get; }
        
        event Action<string> Destroyed;
        
        void Init(GameManager gameManager, EntityData entityData);
    }
}