using System;
using Data;
using Logic;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Services
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField]
        private Timer _timer;
        [SerializeField]
        private RectTransform _activeArea;
        [SerializeField]
        private GameObject _boot;
        [SerializeField]
        private ControllerUI _controllerUI;

        private LevelData _levelData;
        private GameManager _gameManager;
        private IBallsSpawner _ballsSpawner;
        private IGameFactory _gameFactory;
        private IUIFactory _uiFactory;
        private WinMenu _winMenu;

        public LevelData LevelData => _levelData;
        public RectTransform ActiveArea => _activeArea;
        public GameObject Boot => _boot;

        public event Action Destroyed;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameFactory = _gameManager.Services.Single<IGameFactory>();
            _uiFactory = _gameManager.Services.Single<IUIFactory>();
            _ballsSpawner = _gameManager.Services.Single<IBallsSpawner>();
            
            _controllerUI.Init();
            _gameManager.Services.RegisterSingle<IInputService>(_controllerUI);
            
            _timer.Init(gameManager);
        }

        public void StartLevel(LevelData levelData)
        {
            Canvas.ForceUpdateCanvases();
            Physics2D.SyncTransforms();
            
            _levelData = levelData;
            SetActiveAreaSize(levelData);
            
            _gameFactory.CreateObstacles(levelData, _activeArea);

            _gameFactory.InitEntity(_boot);
            _ballsSpawner.StartLevel(this);
            
            _timer.Completion += Win;
        }

        private void Win()
        {
            _controllerUI.Block = true;
            _winMenu = _uiFactory.CreateUiElement<WinMenu>(AssetPath.WinMenu);
        }

        private void SetActiveAreaSize(LevelData levelData)
        {
            Vector2 activeAreaSize = 
                new Vector2(_activeArea.rect.size.x * Const.PROPORTION_CANVAS_1080X1920.x, 
                    _activeArea.rect.size.y * Const.PROPORTION_CANVAS_1080X1920.y);
            
            levelData.MinPosition = (Vector2) _activeArea.transform.position - activeAreaSize / 2;
            levelData.MaxPosition = (Vector2) _activeArea.transform.position + activeAreaSize / 2;
        }

        private void OnDestroy()
        {
            _gameManager.Services.RegisterSingle<IInputService>(null);
            
            if(_winMenu)
                Destroy(_winMenu.gameObject);
            
            Destroyed?.Invoke();
        }
    }
}