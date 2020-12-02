using UnityEngine;
using DG.Tweening;

public class MovingObject : MonoBehaviour
{
    private Route _route;

    private bool _canMove;

    public void Init(Route route)
    {
        _route = route;

        _route.onPointCreateOrRemoveAction += ChangeCanMoveBoolState;
    }

    public void MoveToWayPoint()
    {
        if (_canMove)
        {
            var wayPoint = _route.GetFirstWayPoint();
            var dir = new Vector3(wayPoint.x, wayPoint.y, 0) - transform.position;
            var dot = Vector3.Dot(transform.right, dir);
            var angle = Vector3.Angle(dir, transform.up);
            float koef = 1;

            if (dot > 0)
            {
                koef = -1;
            }

            transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 0, angle) * koef, 0.3f).OnComplete(() =>
              {
                  transform.DOMove(wayPoint, 1f).OnComplete(() =>
                  {
                      _route.RemoveWayPoint(wayPoint);

                      MoveToWayPoint();
                  });
              });
        }
    }

    public void ChangeCanMoveBoolState(bool canMove)
    {
        _canMove = canMove;

        if (_canMove)
        {
            MoveToWayPoint();
        }
    }

    public void StopMoving()
    {
        transform.DOKill();
    }
}
