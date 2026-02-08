using Entitas;

public class ViewMoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> entities;
    public ViewMoveSystem(Contexts context)
    {
        entities = context.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Position,
                    GameMatcher.View));
    }
    public void Execute()
    {
        foreach (var entity in entities)
        {
            entity.view.Value.transform.position = entity.position.Value;
        }
    }
}

