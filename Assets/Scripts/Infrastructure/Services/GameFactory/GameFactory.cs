using System.Collections;
using System.Collections.Generic;
using Data;
using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private GameManager _gameManager;
        private IStaticDataService _staticDataService;

        private Dictionary<string, IEntity> _allEntities = new Dictionary<string, IEntity>();
        public Dictionary<string, IEntity> AllEntities => _allEntities;

        private int DISTANCE_TO_OBSTACLES = 10;

        public void Init(GameManager gameManager, IStaticDataService staticDataService)
        {
            _gameManager = gameManager;
            _staticDataService = staticDataService;
        }

        public GameObject CreateObstacles(LevelData levelData, RectTransform activeArea) => 
            Object.Instantiate(levelData.Obstacles, activeArea);

        public GameObject SpawnBall(LevelData levelData, Transform activeArea)
        {
            EntityData entityData = _staticDataService.GetEntityData(EEntityType.Ball);

            float ballRadius = entityData.Prefab.GetComponent<CircleCollider2D>().radius + DISTANCE_TO_OBSTACLES;
            ballRadius *= Const.PROPORTION_CANVAS_1080X1920.y;

            Vector3 spawnPosition = SpawnPosition(levelData, ballRadius);

            GameObject entityGO = Object.Instantiate(entityData.Prefab, spawnPosition, Quaternion.identity, activeArea);
                
            return InitEntity(entityGO, entityData);
        }

        private Vector3 SpawnPosition(LevelData levelData, float ballRadius)
        {
            Vector3 spawnPosition = RandomPosition(levelData);

            while (Physics2D.OverlapCircle(spawnPosition, ballRadius) != null)
                spawnPosition = RandomPosition(levelData);
            
            return spawnPosition;
        }

        private Vector3 RandomPosition(LevelData levelData)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(levelData.MinPosition.x, levelData.MaxPosition.x),
                Random.Range(levelData.MinPosition.y, levelData.MaxPosition.y),
                0
            );
            
            return spawnPosition;
        }

        public GameObject InitEntity(GameObject entityGO, EntityData entityData = null)
        {
            IEntity entity = entityGO.GetComponent<IEntity>();
            if (entity != null)
            {
                if(entityData == null)
                    entityData = _staticDataService.GetEntityData(entity.EntityType);
                entity.Init(_gameManager, entityData);
                entity.Destroyed += EntityDeleted;
                _allEntities.Add(entity.ID, entity);
            }
            else
                Debug.LogError($"There is no IEntity on the prefab: {entityData.Prefab}");

            return entityGO;
        }

        private void EntityDeleted(string id)
        {
            _allEntities[id].Destroyed -= EntityDeleted;
            _allEntities.Remove(id);
        }
    }
}