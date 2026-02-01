using ECS;
using Entitas;
using UnityEngine;

namespace Assets.Code.ECS.Services
{
    public class GameController : MonoBehaviour
    {
        Systems _systems;
        private void Start()
        {
            var contexts = Contexts.sharedInstance;

            _systems = new Feature("Systems").Add(new TutorialSystems(contexts));
            
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
