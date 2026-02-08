using Entitas;
using UnityEngine;

public class ViewSpawnSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _bullets;
    private readonly IViewFactory _viewFactory;
    public ViewSpawnSystem(Contexts contexts, IViewFactory viewFactory)
    {
        _bullets = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Position).NoneOf(GameMatcher.View));
        _viewFactory = viewFactory;
    }
    public void Execute()
    {
        foreach (var entity in _bullets.GetEntities())
        {
            GameObject go;

            if (entity.isBullet)
                go = _viewFactory.CreateBulletView();
            else
                go = _viewFactory.CreateUnitView(entity.team.Color);

            go.transform.position = entity.position.Value;
            entity.AddView(go);
        }
    }
}

