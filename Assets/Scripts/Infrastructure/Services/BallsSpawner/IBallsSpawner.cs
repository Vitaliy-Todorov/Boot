using System;

namespace Infrastructure.Services
{
    public interface IBallsSpawner : IService
    {
        event Action DestroyedBallEvent;
        public void Init(GameManager gameManager);

        public void StartLevel(ILevelManager levelManager);
    }
}