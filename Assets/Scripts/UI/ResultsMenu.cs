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
            for (int i = 0; i < dataService.ResultsTable.Count; i++) 
                CreateResultUI(i+1, dataService.ResultsTable[i]);
            /*foreach (Result result in dataService.ResultsTable) 
                CreateResultUI(1, result);*/

            _back.onClick.AddListener(Back);
        }

        private void Back()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private ResultUI CreateResultUI(int place, Result result)
        {
            GameObject menuGO = _assetProvider.Instantiate(AssetPath.ResultUI, _resultsTableUI);
            
            ResultUI resultUI = menuGO.GetComponentInChildren<ResultUI>();
            if (resultUI != null)
                resultUI.Init(place, result);
            else
                Debug.LogError($"This prefab has no {typeof(ResultUI)}");

            return resultUI;
        }
    }
}