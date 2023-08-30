using Infrastructure.Services;
using Infrastructure.States;

namespace Scripts.Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState, TPlayload>(TPlayload playload) where TState : class, IPlaylaodedState<TPlayload>;
        void Enter<TState>() where TState : class, IState;
    }
}