using Entitas;
using UnityEngine;

public class ShootingSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private readonly GameContext _gameContext;
    public ShootingSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.CanShoot,
                    GameMatcher.Position,
                    GameMatcher.Team,
                    GameMatcher.MoveDirection));
    }
    public void Execute()
    {
        foreach (var entity in _entities)
        {
            Vector3 bulletPos = entity.position.Value + entity.moveDirection.Value * 1.5f;
            Vector3 bulletDirection = entity.moveDirection.Value;

            var bullet = _gameContext.CreateEntity();
            bullet.isBullet = true;
            bullet.AddDamage(1);
            bullet.AddSpeed(13f);
            bullet.AddPosition(bulletPos);
            bullet.AddMoveDirection(bulletDirection);
            bullet.AddTeam(entity.team.Color);
        }
    }
}

