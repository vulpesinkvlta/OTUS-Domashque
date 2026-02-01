

using Entitas;

namespace ECS
{
    public class CleanupDebugMessageSystem : ICleanupSystem
    {
        private readonly GameContext _contexts;
        private readonly IGroup<GameEntity> _debugMessages;
        public CleanupDebugMessageSystem(Contexts contexts)
        {
            _contexts = contexts.game;
            _debugMessages = _contexts.GetGroup(GameMatcher.DebugMessage);            
        }
        public void Cleanup()
        {
            foreach (var e in _debugMessages.GetEntities())
            {
                e.Destroy();
            }
        }
    }
}
