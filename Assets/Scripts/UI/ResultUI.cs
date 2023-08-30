using Data;
using Infrastructure;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        public TMP_Text _name;
        [SerializeField]
        public TMP_Text _score;
        
        private Result _result;
        
        public void Init(Result result)
        {
            _result = result;
            
            _name.text = _result.Name;
            _score.text = _result.Score.ToString();
        }
    }
}