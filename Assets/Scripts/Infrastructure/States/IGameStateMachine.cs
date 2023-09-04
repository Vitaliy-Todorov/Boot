using Infrastructure;
using Infrastructure.Services;
using Infrastructure.States;

namespace Scripts.Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        public void Init(GameManager gameManager, IUIFactory uiFactory);
        void Enter<TState, TPlayload>(TPlayload playload) where TState : class, IPlaylaodedState<TPlayload>;
        void Enter<TState>() where TState : class, IState;
    }
}