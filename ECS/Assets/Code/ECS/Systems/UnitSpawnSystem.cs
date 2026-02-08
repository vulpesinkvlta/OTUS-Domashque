using Entitas;
using UnityEngine;

namespace ECS
{
    public class UnitSpawnSystem : IInitializeSystem
    {
        private readonly GameContext _context;

        public UnitSpawnSystem(Contexts context)
        {
            _context = context.game;
        }

        public void Initialize()
        {
            int columns = 10;
            float spacing = 4f;

            for (int i = 0; i <= 99; i++)
            {
                int xIndex = i % columns;
                int zIndex = i / columns;
                float startPos = 30f;
                float xPos = startPos + xIndex * spacing;
                float zPos = (zIndex - 5) * spacing;

                var e = _context.CreateEntity();
                e.AddTeam(TeamColor.Red);
                e.AddHealth(10);
                e.AddSpeed(5f);
                e.AddMoveDirection(new Vector3(-1, 0, 0));
                e.AddPosition(new Vector3(xPos, 0, zPos));
            }
            for (int i = 0; i <= 99; i++)
            {
                int xIndex = i % columns;
                int zIndex = i / columns;
                float startPos = -30f;
                float xPos = startPos - xIndex * spacing;
                float zPos = (zIndex - 5) * spacing;

                var e = _context.CreateEntity();
                e.AddTeam(TeamColor.Blue);
                e.AddHealth(10);
                e.AddSpeed(5f);
                e.AddMoveDirection(new Vector3(1, 0, 0));
                e.AddPosition(new Vector3(xPos, 0, zPos));
            }
            
        }
    }
}
