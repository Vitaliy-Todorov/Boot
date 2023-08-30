using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Result
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _score;

        public string Name => _name;
        public int Score => _score;

        public Result(string name, int score)
        {
            _name = name;
            _score = score;
        }
    }
}