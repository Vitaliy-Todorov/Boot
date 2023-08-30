using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameLoopScreen : MonoBehaviour, IUiElement
    {
        [SerializeField] 
        private Button _back;
        [SerializeField] 
        private TMP_Text _counterText;
        
        private GameStateMachine _stateMachine;
        private IDataService _dataService;

        public void Init(GameManager gameManager)
        {
            _stateMachine = gameManager.StateMachine;
            _dataService = gameManager.Services.Single<IDataService>();

            _back.onClick.AddListener(Back);

            _dataService.AddPointEvent += AddPoint;
        }

        private void Back()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private void AddPoint()
        {
            _counterText.text = _dataService.Score.ToString();
        }
    }
}