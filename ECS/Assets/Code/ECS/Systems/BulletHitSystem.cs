using Entitas;
using System.Collections;
using UnityEngine;

public class BulletHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _units;
    private readonly IGroup<GameEntity> _bullets;
    public BulletHitSystem(Contexts contexts)
    {
        _units = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Health,
                GameMatcher.Team,
                GameMatcher.Position).NoneOf(GameMatcher.Destroyed));
        _bullets = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Damage,
                GameMatcher.Position,
                GameMatcher.Bullet).NoneOf(GameMatcher.Destroyed));
    }

    public void Execute()
    {
        var bullets = _bullets.GetEntities();
        var units = _units.GetEntities();

        foreach (var bullet in bullets)
        {
            Vector3 bulletPosition = bullet.position.Value;

            foreach (var unit in units)
            {
                if (unit.team.Color == bullet.team.Color)
                    continue;

                float distance = Vector3.Distance(unit.position.Value, bulletPosition);

                if (distance < 1f)
                {
                    unit.ReplaceHealth(unit.health.Value - bullet.damage.Value);
                    bullet.isDestroyed = true;
                    break;
                }
            }
        }
    }
}

