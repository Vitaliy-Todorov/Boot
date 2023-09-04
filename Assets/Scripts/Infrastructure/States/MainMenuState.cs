using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class MainMenuState : IState
    {
        private IUIFactory _uiFactory;
        private MainMenu _mainMenu;

        public MainMenuState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
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