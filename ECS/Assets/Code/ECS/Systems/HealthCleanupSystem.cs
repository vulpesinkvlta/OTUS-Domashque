using Entitas;

public class HealthCleanupSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _aliveUnits;
    public HealthCleanupSystem(Contexts contexts)
    {
        _aliveUnits = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Health).NoneOf(GameMatcher.Destroyed));
    }

    public void Execute()
    {
        foreach (var unit in _aliveUnits.GetEntities())
        {
            if (unit.health.Value <= 0)
                unit.isDestroyed = true;
        }
    }
}

