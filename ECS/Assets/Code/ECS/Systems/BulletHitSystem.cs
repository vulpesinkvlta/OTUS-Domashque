using Entitas;
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
        foreach (var bullet in _bullets)
        {
            Vector3 bulletPosition = bullet.position.Value;
            foreach (var units in _units)
            {
                if (units.team.Color == bullet.team.Color)
                    continue;

                Vector3 unitPosition = units.position.Value;
                float distance = Vector3.Distance(unitPosition, bulletPosition);
                if(distance < 0.5f)
                {
                    units.ReplaceHealth(units.health.Value - bullet.damage.Value);
                    bullet.isDestroyed = true;
                    break;
                }
            }
        }
    }
}

