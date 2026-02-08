
public class ViewFeature : Feature
{
    public ViewFeature(Contexts contexts, IViewFactory factory) : base("View")
    {
        Add(new ViewSpawnSystem(contexts, factory));
        Add(new ViewMoveSystem(contexts));
        Add(new ViewDestroySystem(contexts, factory));
    }
}

