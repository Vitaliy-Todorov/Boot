using System;
using System.Collections;
using Data;
using Infrastructure;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Entities
{
    [RequireComponent (typeof (Rigidbody2D))]
    public class BootMovement : MonoBehaviour, IMovement
    {
        private EntityData _entityData;
        private Rigidbody2D _rb;
        private ILevelManager _levelManager;
        private IInputService _inputService;

        private Vector3 MinPosition => _levelManager.LevelData.MinPosition;
        private Vector3 MaxPosition => _levelManager.LevelData.MaxPosition;
        private float Speed => _entityData.Speed * Const.PROPORTION_CANVAS_1080X1920.y;

        public void Init(GameManager gameManager, EntityData entityData)
        {
            _levelManager = gameManager.Services.Single<ILevelManager>();
            _inputService = gameManager.Services.Single<IInputService>();
            _entityData = entityData;
            
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 direction = _inputService.GetAxes();

            Vector2 nexPosition = (Vector2) transform.position + direction * Speed * Time.deltaTime;
            if(Helper.Contains(nexPosition, MinPosition, MaxPosition))
                _rb.MovePosition(_rb.position + direction * Speed * Time.deltaTime);
            else
                _rb.velocity = Vector2.zero;
        }
    }
}