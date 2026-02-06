using Entitas;
using UnityEngine;

namespace ECS
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector3 Position;
    }
}
