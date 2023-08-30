using System;
using System.Collections;
using Data;
using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Logic
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] 
        private Scrollbar _timerScrollbar;
        [SerializeField] 
        private TMP_Text _timerText;
 
        private float _timeLeft;
        private readonly float _gameLoopTime = Const.GAME_LOOP_TIME;

        public event Action Completion;

        public void Init(GameManager gameManager)
        {
            _timeLeft = _gameLoopTime;
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            while (_timeLeft > 0)
            {
                float minutes = Mathf.FloorToInt(_timeLeft / 60);
                float seconds = Mathf.FloorToInt(_timeLeft % 60);
                _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
                
                float normalizedValue = Mathf.Clamp(_timeLeft / _gameLoopTime, 0.0f, 1.0f);
                _timerScrollbar.size = normalizedValue;
                
                _timeLeft -= Time.deltaTime;
                
                yield return null;
            }
            
            Completion?.Invoke();
        }
    }
}
