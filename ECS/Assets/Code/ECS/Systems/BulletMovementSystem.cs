using Entitas;
using UnityEngine;

public class BulletMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _bullets;
    public BulletMovementSystem(Contexts contexts)
    {
        _bullets = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.MoveDirection,
                    GameMatcher.Position,
                    GameMatcher.Speed,
                    GameMatcher.Bullet));
    }
    public void Execute()
    {
        float delta = Time.deltaTime;
        foreach (var bullet in _bullets)
        {
            Vector3 newPosition = bullet.position.Value + bullet.moveDirection.Value * bullet.speed.Value * delta;
            bullet.ReplacePosition(newPosition);
        }
    }
}

