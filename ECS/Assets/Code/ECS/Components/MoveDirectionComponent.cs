using Entitas;
using UnityEngine;


namespace ECS
{
    [Game]
    public class MoveDirectionComponent : IComponent 
    {
        public Vector3 Value;
    }
}
