using Entitas;
using UnityEngine;

public class LifetimeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _bullets;

    public LifetimeSystem(Contexts contexts)
    {
        _bullets = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Bullet,
            GameMatcher.LifeTime));
    }

    public void Execute()
    {
        float delta = Time.deltaTime;

        foreach (var entity in _bullets)
        {
            float timeLeft = entity.lifeTime.Value - delta;
            entity.ReplaceLifeTime(timeLeft);

            if (timeLeft <= 0)
                entity.isDestroyed = true;
        }
    }
}
