using System.Collections.Generic;
using Data;
using UI;

namespace Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        List<LevelData> AllLevelData { get; }
        public void Init();
        LevelData GetLevelData(ELevel level);
        EntityData GetEntityData(EEntityType entityType);
    }
}