using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "StaticData/Entity")]
    public class EntityStaticData : ScriptableObject
    {
        public EEntityType EntityType => EntityData.EntityType;
        public EntityData EntityData;
    }
}