using UnityEngine;

namespace Infrastructure.Services
{
    public interface IInputService : IService
    {
        bool Block { get; set; }
        Vector2 GetAxes();
    }
}