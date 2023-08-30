using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class MainMenuState : IState
    {
        private readonly GameManager _gameManager;
        private IUIFactory _uiFactory;
        private MainMenu _mainMenu;

        public MainMenuState(GameManager gameManager)
        {
            _gameManager = gameManager;
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
        }

        public void Enter()
        {
            _mainMenu = _uiFactory.CreateUiElement<MainMenu>(AssetPath.MainMenu);
        }

        public void Exit()
        {
            Object.Destroy(_mainMenu.gameObject);
        }
    }
}