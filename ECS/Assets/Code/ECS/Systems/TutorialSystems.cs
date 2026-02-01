using Entitas;

namespace ECS
{
    public class TutorialSystems : Feature
    {
        public TutorialSystems(Contexts contexts) : base("Tutorial Systems") 
        {
            Add(new HelloWorldSystem(contexts));
            Add(new DebugMessageSystem(contexts));
            Add(new CleanupDebugMessageSystem(contexts));
            Add(new LogMouseClickSystem(contexts));
        }
    }
}
