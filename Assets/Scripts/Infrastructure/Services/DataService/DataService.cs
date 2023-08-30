using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Infrastructure.Services
{
    [Serializable]
    public class DataService : IDataService
    {
        private IBallsSpawner _ballsSpawner;
        
        private int _counter;
        private SaveData _saveData = new SaveData();
        private List<Result> _resultsTable = new List<Result>();
        private const string SAVE_DATA_KEY = "SaveData";

        public int Score => _counter;
        public List<Result> ResultsTable => _resultsTable;
        
        public event Action AddPointEvent;
        
        public void Init(GameManager gameManager)
        {
            _ballsSpawner = gameManager.Services.Single<IBallsSpawner>();
            _ballsSpawner.DestroyedBallEvent += AddPoint;
        }

        public void AddPoint()
        {
            _counter++;
            AddPointEvent?.Invoke();
        }
        
        public void ClearLevelData()
        {
            _counter = 0;
        }

        public void AddResult(string name)
        {
            _resultsTable.Add(new Result(name, Score));
            _resultsTable = _resultsTable.OrderByDescending(result => result.Score).ToList();

            Save();
        }

        private void Save()
        {
            _saveData.ResultsTable = _resultsTable;
            
            string resultsTable = JsonUtility.ToJson(_saveData);
            PlayerPrefs.SetString(SAVE_DATA_KEY, resultsTable);
        }

        public void Load()
        {
            if(PlayerPrefs.HasKey(SAVE_DATA_KEY))
            {
                string resultsTable = PlayerPrefs.GetString(SAVE_DATA_KEY);
                _saveData = JsonUtility.FromJson<SaveData>(resultsTable);
                
                _resultsTable = _saveData.ResultsTable;
            }
            
        }
    }
}