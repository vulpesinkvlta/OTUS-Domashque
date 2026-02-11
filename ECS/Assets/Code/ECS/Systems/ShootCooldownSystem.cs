using Entitas;
using UnityEngine;

public class ShootCooldownSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    public ShootCooldownSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.ShootCooldown).NoneOf(GameMatcher.Destroyed));
    }
    public void Execute()
    {
        float delta = Time.deltaTime;
        foreach (var entity in _entities.GetEntities())
        {
            if(entity.shootCooldown.Valuye > 0)
            {
                entity.ReplaceShootCooldown(entity.shootCooldown.Valuye - delta);
            }
        }
    }
}

