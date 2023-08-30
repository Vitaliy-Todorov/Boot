using Data;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UIFactory : IUIFactory
    {
        private GameManager _gameManager;
        private IAssetProvider _assetProvider;
        
        private LevelData _currentLevelData;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
            _assetProvider = gameManager.Services.Single<IAssetProvider>();
        }

        public TMenu CreateUiElement<TMenu>(string path) where TMenu : IUiElement
        {
            GameObject menuGO = _assetProvider.Instantiate(path, _gameManager.Canvas);
            
            TMenu mainMenu = menuGO.GetComponentInChildren<TMenu>();
            if (mainMenu != null)
                mainMenu.Init(_gameManager);
            else
                Debug.LogError($"This prefab has no {typeof(TMenu)}");

            return mainMenu;
        }
    }
}