using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinMenu : MonoBehaviour, IUiElement
    {
        [SerializeField] 
        private TMP_Text _score;
        [SerializeField] 
        private TMP_InputField _inputField;
        [SerializeField] 
        private Button _acceptButton;

        private GameStateMachine _stateMachine;
        private IDataService _dataService;
        private IInputService _inputService;

        public void Init(GameManager gameManager)
        {
            _stateMachine = gameManager.StateMachine;
            _dataService = gameManager.Services.Single<IDataService>();
            _inputService = gameManager.Services.Single<IInputService>();

            SetScore();
            
            _acceptButton.onClick.AddListener(Accept);
        }

        private void Accept()
        {
            _dataService.AddResult(_inputField.text);
            _dataService.ClearLevelData();
            _inputService.Block = false;
            
            _stateMachine.Enter<ResultsState>();
        }

        private void SetScore()
        {
            _score.text = $"{_dataService.Score.ToString()} balls";
        }
    }
}