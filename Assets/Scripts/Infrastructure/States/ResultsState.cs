using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.States
{
    public class ResultsState : IState
    {
        private readonly IUIFactory _uiFactory;
        private ResultsMenu _resultsMenu;

        public ResultsState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
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