using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControler : MonoBehaviour
{
    [SerializeField] private SimpleLimbIK ik;
    [SerializeField] private Graber graber;
    private Camera _mainCam;
    private Vector2 _mousePosition;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        ik.SetTargetPosition(_mousePosition);
    }

    public void OnMouseMove(InputValue value)
    {
        _mousePosition = _mainCam.ScreenToWorldPoint(value.Get<Vector2>());
    }

    public void OnMouseClick(InputValue value)
    {
        graber.Grab(value.isPressed);
    }
}