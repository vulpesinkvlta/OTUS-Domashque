using UnityEngine;

public interface IViewFactory
{
    GameObject CreateUnitView(TeamColor color);
    GameObject CreateBulletView(TeamColor color);
    
    void Release(GameObject go);
}

