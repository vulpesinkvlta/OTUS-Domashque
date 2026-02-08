using Entitas;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ViewDestroySystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> entities;
    private readonly IViewFactory _viewFactory;
    public ViewDestroySystem(Contexts contexts, IViewFactory viewFactory)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.View,
                    GameMatcher.Destroyed));
        _viewFactory = viewFactory;
    }
    public void Execute()
    {
        foreach (var entity in entities.GetEntities())
        {
            _viewFactory.Release(entity.view.Value);
            entity.RemoveView();
        }
    }
}

