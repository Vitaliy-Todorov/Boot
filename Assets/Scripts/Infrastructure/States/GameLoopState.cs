using Data;
using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IPlaylaodedState<ELevel>
    {
        private readonly GameManager _gameManager;
        private readonly IUIFactory _uiFactory;
        private GameLoopScreen _gameCardsMenu;
        private IDataService _dataService;
        private IStaticDataService _staticDataService;

        public GameLoopState(GameManager gameManager)
        {
            _gameManager = gameManager;
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
            _staticDataService = _gameManager.Services.Single<IStaticDataService>();
            _dataService = _gameManager.Services.Single<IDataService>();
        }

        public void Enter(ELevel levelName)
        {
            _gameCardsMenu = _uiFactory.CreateUiElement<GameLoopScreen>(AssetPath.GameLoopHab);
            
            ILevelManager levelManager = _gameCardsMenu.GetComponentInChildren<ILevelManager>();
            levelManager.Init(_gameManager);
            _gameManager.Services.RegisterSingle<ILevelManager>(levelManager);

            LevelData levelData = _staticDataService.GetLevelData(levelName);
            _gameManager.Services.Single<ILevelManager>()
                .StartLevel(levelData);
        }

        public void Exit()
        {
            _dataService.ClearLevelData();
            _gameManager.Services.RegisterSingle<ILevelManager>(null);
            Object.Destroy(_gameCardsMenu.gameObject);
        }
    }
}