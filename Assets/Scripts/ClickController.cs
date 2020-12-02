using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController
{
    public delegate void onMouseClick(Vector2 vector2);
    public event onMouseClick onMouseClickAction;

    private Camera _camera;

    public ClickController()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Vector2 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                onMouseClickAction?.Invoke(worldPosition);
            }
        }
    }
}
