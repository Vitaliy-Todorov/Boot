using System.Collections.Generic;
using Data;
using Entities;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameFactory : IService
    {
        public Dictionary<string, IEntity> AllEntities { get; }
        public GameObject InitEntity(GameObject entityGO, EntityData entityData = null);
        public GameObject SpawnBall(LevelData levelData, Transform card);
        GameObject CreateObstacles(LevelData levelData, RectTransform activeArea);
    }
}