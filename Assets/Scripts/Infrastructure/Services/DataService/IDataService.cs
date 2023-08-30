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
        void AddPoint();
        void ClearLevelData();
        void AddResult(string name);
        void Load();
    }
}