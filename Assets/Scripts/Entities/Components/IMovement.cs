using Data;
using Infrastructure;

namespace Entities
{
    public interface IMovement
    {
        void Init(GameManager gameManager, EntityData entityData);
    }
}