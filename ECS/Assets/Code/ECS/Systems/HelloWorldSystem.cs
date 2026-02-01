using Entitas;

namespace ECS
{
    public class HelloWorldSystem : IInitializeSystem
    {
        private readonly GameContext _contexts;

        public HelloWorldSystem(Contexts contexts)
        {
            _contexts = contexts.game;
        }
        public void Initialize()
        {
            _contexts.CreateEntity().AddDebugMessage("Hello World!");
        }
    }
}
