using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Scripts.Infrastructure.States;

namespace Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExcitableState> _states;
        private IExcitableState _activeState;
        private GameManager _gameManager;

        public void Init(GameManager gameManager, IUIFactory uiFactory)
        {
            _states = new Dictionary<Type, IExcitableState>()
            {
                [typeof(MainMenuState)] = new MainMenuState(uiFactory),
                [typeof(GameCardsState)] = new GameCardsState(uiFactory),
                [typeof(GameLoopState)] = new GameLoopState(gameManager),
                [typeof(ResultsState)] = new ResultsState(uiFactory),
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

        private TState ChangeState<TState>() where TState : class, IExcitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TExitablState GetState<TExitablState>() where TExitablState : class, IExcitableState =>
            _states[typeof(TExitablState)] as TExitablState;
    }
}