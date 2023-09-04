using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameCardsState : IState
    {
        private readonly GameManager _gameManager;
        private readonly IUIFactory _uiFactory;
        private GameCardsMenu _gameCardsMenu;

        public GameCardsState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _gameCardsMenu = _uiFactory.CreateUiElement<GameCardsMenu>(AssetPath.GameCardsMenu);
        }

        public void Exit()
        {
            Object.Destroy(_gameCardsMenu.gameObject);
        }
    }
}