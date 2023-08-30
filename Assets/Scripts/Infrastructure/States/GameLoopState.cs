using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameManager _gameManager;
        private readonly IUIFactory _uiFactory;
        private GameLoopScreen _gameCardsMenu;
        private IDataService _dataService;

        public GameLoopState(GameManager gameManager)
        {
            _gameManager = gameManager;
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
            _dataService = _gameManager.Services.Single<IDataService>();
        }

        public void Enter()
        {
            _gameCardsMenu = _uiFactory.CreateUiElement<GameLoopScreen>(AssetPath.GameLoopHab);
            
            ILevelManager levelManager = _gameCardsMenu.GetComponentInChildren<ILevelManager>();
            levelManager.Init(_gameManager);
            _gameManager.Services.RegisterSingle<ILevelManager>(levelManager);
        }

        public void Exit()
        {
            _dataService.ClearLevelData();
            _gameManager.Services.RegisterSingle<ILevelManager>(null);
            Object.Destroy(_gameCardsMenu.gameObject);
        }
    }
}