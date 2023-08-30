using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public ELevel LevelName => LevelData.LevelName;
        public LevelData LevelData;
    }
}