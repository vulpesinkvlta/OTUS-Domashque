using UnityEngine;

public interface IViewFactory
{
    GameObject CreateUnitView(TeamColor color);
    GameObject CreateBulletView();
    
    void Release(GameObject go);
}

