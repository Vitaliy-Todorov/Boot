using System;
using System.Collections.Generic;
using Data;
using Entities;
using UnityEngine;

namespace Infrastructure.Services
{
    public class BallsSpawner : IBallsSpawner
    {
        private GameManager _gameManager;
        private IGameFactory _gameFactory;
        private ILevelManager _levelManager;
        
        private Dictionary<string,IEntity> _balls = new Dictionary<string, IEntity>();
        
        private readonly int _ballsAmountOnField = Const.BALLS_AMOUNT_ON_FIELD;

        public event Action DestroyedBallEvent;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameFactory = _gameManager.Services.Single<IGameFactory>();
        }

        public void StartLevel(ILevelManager levelManager)
        {
            _levelManager = levelManager;

            _levelManager.Destroyed += Destroy;
            
            for (int i = _ballsAmountOnField; i > 0; i--)
                SpawnBall();
        }

        private IEntity SpawnBall()
        {
            GameObject ballGO = _gameFactory.SpawnBall(_levelManager.LevelData, _levelManager.ActiveArea);
            IEntity ball = ballGO.GetComponent<IEntity>();
            ball.Destroyed += DestroyedBall;
            _balls.Add(ball.ID, ball);
            
            return ball;
        }

        private void DestroyedBall(string id)
        {
            _balls.Remove(id);
            DestroyedBallEvent?.Invoke();
            SpawnBall();
        }

        private void Destroy()
        {
            foreach ((_, IEntity ball) in _balls)
            {
                ball.Destroyed -= DestroyedBall;
            }
        }
    }
}