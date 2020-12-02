using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class EntryPoint : MonoBehaviour
{
    private IPool _pool;

    private ClickController _clickController;
    private Route _route;
    private RouteView _routeView;
    private PauseButtonScript _pauseButtonScript;
    private UIController _uIController;

    [SerializeField]
    private MovingObject _movingObject;
    [SerializeField]
    private GameObject _pointPrefab;
    [SerializeField]
    private Transform _dotsParent;
    [SerializeField]
    private Button _pauseButton;    

    private void Start()
    {
        _pool = new Pool(_pointPrefab, _dotsParent);

        _clickController = new ClickController();
        _routeView = new RouteView(_pool, _dotsParent);
        _route = new Route(_routeView);
        _pauseButtonScript = new PauseButtonScript(_pauseButton);
        _uIController = new UIController(_movingObject);
        _movingObject.Init(_route);

        _clickController.onMouseClickAction += _route.SetNewWayPoint;
        _pauseButtonScript.onPauseButtonClickAction += _uIController.OnPauseButtonClick;
    }

    private void Update()
    {
        _clickController.Update();
    }
}
