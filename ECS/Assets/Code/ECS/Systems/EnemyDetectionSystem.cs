using Entitas;
using UnityEngine;

namespace ECS
{
    public class EnemyDetectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        public EnemyDetectionSystem(Contexts contexts) 
        {
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(
                        GameMatcher.Team,
                        GameMatcher.Position));
        }
        public void Execute()
        {
            var units = _entities.GetEntities();
            foreach (var unit in units)
            {
                bool enemyFound = false;
                foreach (var other in units)
                {
                    if (other == unit)
                        continue;                   
                    if (other.team.Color == unit.team.Color)
                        continue;
                    float distanceToEnemy = Vector3.Distance(
                        unit.position.Value, 
                        other.position.Value);
                    if(distanceToEnemy < 15f)
                    {
                        enemyFound = true;
                        break;      
                    }
                }
                
                if (enemyFound)
                {
                        unit.isCanShoot = true;
                }
                else
                {
                        unit.isCanShoot = false;
                }
            }
        }
    }
}
