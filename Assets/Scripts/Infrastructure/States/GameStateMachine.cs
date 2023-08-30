using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Scripts.Infrastructure.States;

namespace Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitablState> _states;
        private IExitablState _activeState;
        private GameManager _gameManager;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;

            AllServices services = _gameManager.Services;
            _states = new Dictionary<Type, IExitablState>()
            {
                [typeof(MainMenuState)] = new MainMenuState(_gameManager),
                [typeof(GameCardsState)] = new GameCardsState(_gameManager),
                [typeof(GameLoopState)] = new GameLoopState(_gameManager),
                [typeof(ResultsState)] = new ResultsState(_gameManager),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPlayload>(TPlayload playload) where TState : class, IPlaylaodedState<TPlayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(playload);
        }

        private TState ChangeState<TState>() where TState : class, IExitablState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TExitablState GetState<TExitablState>() where TExitablState : class, IExitablState =>
            _states[typeof(TExitablState)] as TExitablState;
    }
}