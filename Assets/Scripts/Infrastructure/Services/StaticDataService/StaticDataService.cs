using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataEntitiesPath = "Data/Entities";
        private const string StaticDataLevelsPath = "Data/Levels";
        
        private Dictionary<EEntityType, EntityData> _entitiesData;
        private Dictionary<ELevel, LevelData> _levelsData;

        public List<LevelData> _allLevelData;
        public List<LevelData> AllLevelData => _allLevelData;

        public void Init(GameManager services)
        {
            _entitiesData = Resources
                .LoadAll<EntityStaticData>(StaticDataEntitiesPath)
                .ToDictionary(entityData => entityData.EntityType, entityData => entityData.EntityData);

            LevelStaticData[] staticLevelsData = Resources.LoadAll<LevelStaticData>(StaticDataLevelsPath);
            
            _levelsData = staticLevelsData.ToDictionary(levelData => levelData.LevelName, levelData => levelData.LevelData);
            
            _allLevelData = staticLevelsData
                .Select(levelData => levelData.LevelData)
                .ToList();
        }
        
        public EntityData GetEntityData(EEntityType entityType) =>
            _entitiesData.TryGetValue(entityType, out EntityData entityData)
                ? entityData
                : EntityDataNull(entityType);

        public LevelData GetLevelData(ELevel level) =>
            _levelsData.TryGetValue(level, out LevelData levelData)
                ? levelData
                : LevelDataNull(level);

        private static LevelData LevelDataNull(ELevel level)
        {
            Debug.Log($"No data found for: {level}");
            return null;
        }

        private static EntityData EntityDataNull(EEntityType entityType)
        {
            Debug.Log($"No data found for: {entityType}");
            return null;
        }
    }
}