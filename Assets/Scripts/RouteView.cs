using UnityEngine;
using System.Collections.Generic;

public class RouteView
{
    private IPool _pool;

    private LineRenderer _routeLine;

    private List<GameObject> _wayPoints;

    public RouteView(IPool pool, Transform dotsParent)
    {
        _wayPoints = new List<GameObject>();

        _pool = pool;
        _routeLine = dotsParent.GetComponent<LineRenderer>();
    }

    public void CreateNewWayPoint(Vector2 position)
    {
        var dot = _pool.Pull();

        dot.transform.position = position;
        _wayPoints.Add(dot);

        _routeLine.positionCount++;
        _routeLine.SetPosition(_routeLine.positionCount - 1, position);
    }

    public void RemoveWayPoint(Vector2 position)
    {
        for (int i = 0; i < _wayPoints.Count; i++)
        {
            if (_wayPoints[i].transform.position == new Vector3(position.x, position.y, 0))
            {
                _pool.Push(_wayPoints[i]);
                _wayPoints.RemoveAt(i);
            }
        }
    }
}
