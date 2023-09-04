using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services
{
    public class ControllerUI : MonoBehaviour, IInputService
    {
        [SerializeField]
        private MyButton _up;
        [SerializeField]
        private MyButton _right;
        [SerializeField]
        private MyButton _down;
        [SerializeField]
        private MyButton _left;

        private Vector2 _axesValue;
        
        public void Init()
        {
            ChangingAxisY(_up, -1);
            ChangingAxisY(_down, 1);
            ChangingAxisX(_right, -1);
            ChangingAxisX(_left, 1);
        }

        private void ChangingAxisY(MyButton up, int upOrDown)
        {
            up.Down += () =>
                _axesValue.y -= upOrDown;
            up.Up += () =>
                _axesValue.y += upOrDown;
        }

        private void ChangingAxisX(MyButton up, int upOrDown)
        {
            up.Down += () =>
                _axesValue.x -= upOrDown;
            up.Up += () =>
                _axesValue.x += upOrDown;
        }

        public bool Block { get; set; }
        public Vector2 GetAxes()
        {
            if (Block)
                return Vector2.zero;
            
            return _axesValue;
        }
    }
}