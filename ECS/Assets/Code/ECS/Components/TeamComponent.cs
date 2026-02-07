using Entitas;

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

