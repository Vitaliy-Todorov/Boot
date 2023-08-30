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

            RegisterServices();
            
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(_canvas);
            
            StateMachine.Enter<MainMenuState>();
        }

        private void RegisterServices()
        {
            BallsSpawner ballsSpawner = new BallsSpawner();
            Services.RegisterSingle<IBallsSpawner>(ballsSpawner);
            
            InitAndRegisterService<IInputService>(new KeysAndMouseInputService());
            IDataService dataService = new DataService();
            InitAndRegisterService<IDataService>(dataService);
            InitAndRegisterService<IStaticDataService>(new StaticDataService());
            InitAndRegisterService<IAssetProvider>(new AssetProvider());
            InitAndRegisterService<IGameFactory>(new GameFactory());
            InitAndRegisterService<IUIFactory>(new UIFactory());
            
            _stateMachine = new GameStateMachine();
            InitAndRegisterService<IGameStateMachine>(_stateMachine);
            
            ballsSpawner.Init(this);
            
            dataService.Load();
        }

        private void InitAndRegisterService<TService>(TService inputService) where TService : IService
        {
            inputService.Init(this);
            Services.RegisterSingle<TService>(inputService);
        }
    }
}