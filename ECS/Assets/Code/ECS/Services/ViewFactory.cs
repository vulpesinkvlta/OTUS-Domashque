using UnityEngine;

public class ViewFactory : IViewFactory
{
    private readonly GameObjectPool _unitPool;
    private readonly GameObjectPool _bulletPool;   
    public ViewFactory(GameObject unitPrefab, GameObject bulletPrefab)
    {
        _unitPool = new GameObjectPool(unitPrefab, 200);
        _bulletPool = new GameObjectPool(bulletPrefab, 500);
    }
    public GameObject CreateBulletView()
    {
        return _bulletPool.Get();
    }

    public GameObject CreateUnitView(TeamColor color)
    {
        var go =  _unitPool.Get();
        var renderer = go.GetComponent<Renderer>();
        renderer.material.color = color == TeamColor.Red ? Color.red : Color.blue;
        return go;
    }

    public void Release(GameObject go)
    {
        if(go.CompareTag("Bullet"))
            _bulletPool.Release(go);
        else 
            _unitPool.Release(go);
    }
}

