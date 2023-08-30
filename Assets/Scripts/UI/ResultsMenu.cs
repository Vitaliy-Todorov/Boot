using Data;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultsMenu : MonoBehaviour, IUiElement
    {
        [SerializeField] 
        private Button _back;
        [SerializeField] 
        private RectTransform _resultsTableUI;
        
        private GameStateMachine _stateMachine;
        private IAssetProvider _assetProvider;

        public void Init(GameManager gameManager)
        {
            _stateMachine = gameManager.StateMachine;
            _assetProvider = gameManager.Services.Single<IAssetProvider>();
            
            IDataService dataService = gameManager.Services.Single<IDataService>();
            foreach (Result result in dataService.ResultsTable) 
                CreateResultUI(result);

            _back.onClick.AddListener(Back);
        }

        private void Back()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private ResultUI CreateResultUI(Result result)
        {
            GameObject menuGO = _assetProvider.Instantiate(AssetPath.ResultUI, _resultsTableUI);
            
            ResultUI resultUI = menuGO.GetComponentInChildren<ResultUI>();
            if (resultUI != null)
                resultUI.Init(result);
            else
                Debug.LogError($"This prefab has no {typeof(ResultUI)}");

            return resultUI;
        }
    }
}