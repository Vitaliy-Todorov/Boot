using System;
using System.Collections.Generic;
using Data;

namespace Infrastructure.Services
{
    public interface IDataService : IService
    {
        event Action AddPointEvent;
        int Score { get; }
        public List<Result> ResultsTable { get; }
        public void Init(IBallsSpawner ballsSpawner);
        void AddPoint();
        void ClearLevelData();
        void AddResult(string name);
        void Load();
    }
}