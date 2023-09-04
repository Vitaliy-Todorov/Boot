using System.Collections.Generic;
using Data;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameCardsMenu : MonoBehaviour, IUiElement
    {
        [SerializeField] 
        private Button _back;
        [SerializeField] 
        private RectTransform _cardsField;

        private GameManager _gameManager;
        private GameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
            _stateMachine = gameManager.StateMachine;
            _staticDataService = _gameManager.Services.Single<IStaticDataService>();

            _back.onClick.AddListener(Back);
            
            foreach (LevelData levelData in _staticDataService.AllLevelData)
            {
                GameObject cardGO = Instantiate(levelData.Card, _cardsField);

                Card card = cardGO.GetComponent<Card>();
                card.Button.onClick.AddListener(() => LoadLevel(card));
            }
        }

        private void Back()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private void LoadLevel(Card card)
        {
            _stateMachine.Enter<GameLoopState, ELevel>(card.LevelName);
        }
    }
}