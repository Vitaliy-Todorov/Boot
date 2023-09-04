using System;

namespace Infrastructure.Services
{
    public interface IBallsSpawner : IService
    {
        event Action DestroyedBallEvent;
        public void Init(IGameFactory gameFactory);

        public void StartLevel(ILevelManager levelManager);
    }
}