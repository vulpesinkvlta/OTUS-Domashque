using Entitas;

namespace ECS
{
    [Game]
    public class TeamComponent : IComponent
    {
        public TeamColor Color;
    }
    
    public enum TeamColor 
    {
        Red,
        Blue
    }
}
