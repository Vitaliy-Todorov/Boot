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

        public void Init(GameManager gameManager, IAssetProvider assetProvider)
        {
            _gameManager = gameManager;
            _assetProvider = assetProvider;
        }

        public TMenu CreateUiElement<TMenu>(string path) where TMenu : IUiElement
        {
            GameObject uiElementGO = _assetProvider.Instantiate(path, _gameManager.Canvas);
            
            TMenu uiElement = uiElementGO.GetComponentInChildren<TMenu>();
            if (uiElement != null)
                uiElement.Init(_gameManager);
            else
                Debug.LogError($"This prefab has no {typeof(TMenu)}");

            return uiElement;
        }
    }
}