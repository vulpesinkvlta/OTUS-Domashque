using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private readonly GameObject _prefab;
    private readonly Transform _parent;
    private readonly Stack<GameObject> _pool = new Stack<GameObject>();

    public GameObjectPool(GameObject prefab, int size, Transform parent = null)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < size; i++)
        {
            var go = Object.Instantiate(prefab, _parent);  
            go.SetActive(false);
            _pool.Push(go);
        }
    }

    public GameObject Get()
    {
        if(_pool.Count > 0 )
        {
            var go = _pool.Pop();
            go.SetActive(true);
            return go;
        }
        
        return Object.Instantiate(_prefab, _parent);
    }

    public void Release(GameObject go)
    {
        go.SetActive(false);
        _pool.Push(go); 
    }
}

