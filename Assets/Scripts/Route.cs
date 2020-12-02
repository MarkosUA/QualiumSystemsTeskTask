using UnityEngine;
using System.Collections.Generic;

public class Route
{
    public delegate void onPointCreateOrRemove(bool create);
    public event onPointCreateOrRemove onPointCreateOrRemoveAction;

    private RouteView _routeView;

    private List<Vector2> _wayPoints;

    private bool _isCanAddingNewPoints;

    public Route(RouteView routeView)
    {
        _routeView = routeView;

        _wayPoints = new List<Vector2>();

        _isCanAddingNewPoints = true;
    }

    public void SetNewWayPoint(Vector2 pointPosition)
    {
        if (_isCanAddingNewPoints)
        {
            _wayPoints.Add(pointPosition);

            _routeView.CreateNewWayPoint(pointPosition);

            if (_wayPoints.Count == 1)
            {
                onPointCreateOrRemoveAction?.Invoke(true);
            }
        }
    }

    public Vector2 GetFirstWayPoint()
    {
        if (_wayPoints.Count > 0)
        {
            return _wayPoints[0];
        }
        else
        {
            Debug.Log("_wayPoints.Count < 0");

            return Vector2.zero;
        }
    }

    public void RemoveWayPoint(Vector2 wayPoint)
    {
        _routeView.RemoveWayPoint(wayPoint);
        _wayPoints.Remove(wayPoint);

        if (_wayPoints.Count == 0)
        {
            onPointCreateOrRemoveAction?.Invoke(false);
        }
    }
}
