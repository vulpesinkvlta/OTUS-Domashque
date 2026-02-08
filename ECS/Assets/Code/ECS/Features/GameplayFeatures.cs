using ECS;

public class GameplayFeatures : Feature
{
    public GameplayFeatures(Contexts contexts) : base("Gameplay")
    {
        Add(new UnitSpawnSystem(contexts));
        Add(new MoveSystem(contexts));
        Add(new EnemyDetectionSystem(contexts));
        Add(new ShootingSystem(contexts));
        Add(new BulletMovementSystem(contexts));
        Add(new BulletHitSystem(contexts));
        Add(new HealthCleanupSystem(contexts));
        Add(new DestroySystem(contexts));
    }
}

