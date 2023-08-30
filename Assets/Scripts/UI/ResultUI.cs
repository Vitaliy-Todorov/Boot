using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        public Image _positionSprite;
        [SerializeField]
        public TMP_Text _position;
        [SerializeField]
        public TMP_Text _name;
        [SerializeField]
        public TMP_Text _score;
        
        private Result _result;
        
        public void Init(int place, Result result)
        {
            _result = result;
            
            _position.text = place.ToString();
            _name.text = _result.Name;
            _score.text = _result.Score.ToString();

            switch (place)
            {
                case 1:
                    _positionSprite.color = Color.red;
                    break;
                case 2:
                    _positionSprite.color = Color.yellow;
                    break;
                case 3:
                    _positionSprite.color = Color.green;
                    break;
            }
        }
    }
}