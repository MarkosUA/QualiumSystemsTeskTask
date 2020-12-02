using UnityEngine;
using System.Collections.Generic;

public class Pool : IPool
{
    private GameObject _pointPrefab;
    private Transform _dotsParent;

    private Stack<GameObject> _pool = new Stack<GameObject>();

    public Pool(GameObject pointPrefab, Transform dotsParent)
    {
        _pointPrefab = pointPrefab;
        _dotsParent = dotsParent;
    }

    public void Push(GameObject gameObject)
    {
        gameObject.SetActive(false);

        _pool.Push(gameObject);
    }

    public GameObject Pull()
    {
        if (_pool.Count > 0)
        {
            var obj = _pool.Pop();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Create();
        }
    }

    private GameObject Create()
    {
        var obj = Object.Instantiate(_pointPrefab, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(_dotsParent);

        return obj;
    }
}
