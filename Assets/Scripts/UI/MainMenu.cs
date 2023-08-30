using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour, IUiElement
    {
        [SerializeField] 
        private Button _start;
        [SerializeField] 
        private Button _results;
        [SerializeField] 
        private Button _policy;
        [SerializeField] 
        private Button _quit;

        private GameStateMachine _stateMachine;

        public void Init(GameManager gameManager)
        {
            _stateMachine = gameManager.StateMachine;
            
            _start.onClick.AddListener(StartGame);
            _results.onClick.AddListener(Results);
            _policy.onClick.AddListener(Policy);
            _quit.onClick.AddListener(Quit);
        }

        private void StartGame() => 
            _stateMachine.Enter<GameCardsState>();

        private void Results() => 
            _stateMachine.Enter<ResultsState>();

        private void Policy() => 
            Application.OpenURL("https://aviabaffishpic.com/politic");

        private void Quit() => 
            Application.Quit();
    }
}
