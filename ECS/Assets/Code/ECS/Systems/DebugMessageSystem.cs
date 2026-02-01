using Entitas;
using UnityEngine;
using System.Collections.Generic;



namespace ECS
{
    public class DebugMessageSystem : ReactiveSystem<GameEntity>
    {
        public DebugMessageSystem(Contexts context) : base(context.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.Log(entity.debugMessage.message);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDebugMessage;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DebugMessage);
        }
    }
}
