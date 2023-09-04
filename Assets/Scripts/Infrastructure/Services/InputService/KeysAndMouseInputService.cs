using UnityEngine;

namespace Infrastructure.Services
{
    public class KeysAndMouseInputService : IInputService
    {
        public bool Block { get; set; }

        public void Init()
        {
            
        }

        public Vector2 GetAxes()
        {
            float directionX = 0;
            float directionY = 0;
            
            if(!Block)
            {
                directionX = Input.GetAxis("Horizontal");
                directionY = Input.GetAxis("Vertical");
            }
            
            return new Vector2(directionX, directionY);
        }
    }
}