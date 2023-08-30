using System.Collections.Generic;
using Data;
using UI;

namespace Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        LevelData GetLevelData(ELevel level);
        EntityData GetEntityData(EEntityType entityType);
        List<LevelData> AllLevelData { get; }
    }
}