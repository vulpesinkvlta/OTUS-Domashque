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
        foreach (var _units in _aliveUnits)
            if(_units.health.Value <= 0)
                _units.isDestroyed = true;
        
    }
}

