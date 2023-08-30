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

        public GameCardsState(GameManager gameManager)
        {
            _gameManager = gameManager;
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
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