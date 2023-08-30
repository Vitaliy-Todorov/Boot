using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Data
{
    [Serializable]
    public class LevelData
    {
        public ELevel LevelName;
        public Vector2 MinPosition;
        public Vector2 MaxPosition;
        public GameObject Obstacles;
        public GameObject Card;
    }
}