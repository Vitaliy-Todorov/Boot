namespace Infrastructure.States
{
    public interface IState : IExcitableState
    {
        void Enter();
    }

    public interface IPlaylaodedState<TPlayload> : IExcitableState
    {
        void Enter(TPlayload playload);
    }

    public interface IExcitableState
    {
        void Exit();
    }
}