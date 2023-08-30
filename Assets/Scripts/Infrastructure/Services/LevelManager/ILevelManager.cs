using System;
using Data;
using Logic;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILevelManager : IService
    {
        LevelData LevelData { get; }
        
        RectTransform ActiveArea { get; }
        GameObject Boot { get; }
        
        
        event Action Destroyed;
        
        void StartLevel(LevelData levelData);
    }
}