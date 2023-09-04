using System.Collections.Generic;
using Data;
using UnityEngine;
using Infrastructure.Services;
using Infrastructure.States;
using Scripts.Infrastructure.States;
using UI;

namespace Infrastructure
{
    public class GameManager : MonoBehaviour
    {
        private AllServices _services;
        private GameStateMachine _stateMachine;
        [SerializeField]
        private RectTransform _canvas;

        public AllServices Services => _services;
        public GameStateMachine StateMachine => _stateMachine;

        public RectTransform Canvas => _canvas;

        private void Awake()
        {
            _services = AllServices.Container;
            new Const(_canvas);

            RegisterAndInitServices();
            Services.Single<IDataService>().Load();
            
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(_canvas);
            
            StateMachine.Enter<MainMenuState>();
        }

        private void RegisterAndInitServices()
        {
            // Register
            IBallsSpawner ballsSpawner = Services.RegisterSingle<IBallsSpawner>(new BallsSpawner());

            IDataService dataService = Services.RegisterSingle<IDataService>(new DataService());
            IStaticDataService staticDataService = Services.RegisterSingle<IStaticDataService>(new StaticDataService());
            IAssetProvider assetProvider = Services.RegisterSingle<IAssetProvider>(new AssetProvider());
            IGameFactory gameFactory = Services.RegisterSingle<IGameFactory>(new GameFactory());
            IUIFactory uiFactory = Services.RegisterSingle<IUIFactory>(new UIFactory());
            
            _stateMachine = (GameStateMachine) Services.RegisterSingle<IGameStateMachine>(new GameStateMachine());
            
            // Init
            dataService.Init(ballsSpawner);
            staticDataService.Init();
            assetProvider.Init();
            gameFactory.Init(this, staticDataService);
            uiFactory.Init(this, assetProvider);

            ballsSpawner.Init(gameFactory);

            _stateMachine.Init(this, uiFactory);
        }
    }
}