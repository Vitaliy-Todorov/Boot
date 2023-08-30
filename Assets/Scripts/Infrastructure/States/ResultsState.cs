using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class ResultsState : IState
    {
        private readonly GameManager _gameManager;
        private readonly IUIFactory _uiFactory;
        private ResultsMenu _resultsMenu;

        public ResultsState(GameManager gameManager)
        {
            _gameManager = gameManager;
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
        }

        public void Enter()
        {
            _resultsMenu = _uiFactory.CreateUiElement<ResultsMenu>(AssetPath.ResultsMenu);
        }

        public void Exit()
        {
            Object.Destroy(_resultsMenu.gameObject);
        }
    }
}