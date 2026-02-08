using Entitas;

public class DestroySystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _entities;
    public DestroySystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Destroyed));
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.Destroy();
        }
    }
}

