using Entitas;
using UnityEngine;

namespace ECS
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject unitPrefab;
        [SerializeField] GameObject bulletPrefab;

        Systems _systems;
        private void Start()
        {
            var contexts = Contexts.sharedInstance;

            var factory = new ViewFactory(unitPrefab, bulletPrefab);

            _systems = new Feature("Systems")
                .Add(new TutorialSystems(contexts))
                .Add(new GameplayFeatures(contexts))
                .Add(new ViewFeature(contexts, factory));
            
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
