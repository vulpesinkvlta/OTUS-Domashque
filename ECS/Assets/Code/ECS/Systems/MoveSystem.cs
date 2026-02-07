using Entitas;
using UnityEngine;

namespace ECS
{
    public class MoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _moves;
        public MoveSystem(Contexts contexts)
        {
            _moves = contexts.game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.MoveDirection,
                    GameMatcher.Position,
                    GameMatcher.Speed    
                    ));                   
        }
        public void Execute()
        {
            float delta = Time.deltaTime;
            foreach (var move in _moves)
            {
                Vector3 currentPos = move.position.Value;
                Vector3 dir = move.moveDirection.Value;
                float speed = move.speed.Value; 
                Vector3 newPosition = currentPos + dir * speed * delta;
                move.ReplacePosition(newPosition);
            }
        }
    }
}
