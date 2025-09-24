using UnityEngine;
using UnityEngine.InputSystem;

public class Graber : MonoBehaviour
{
    [SerializeField] private bool _debug;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private LayerMask grabableLayer;
    [SerializeField] private float grabRadius = 0.5f;
    private Grabable _currentGrabable;

    void Update()
    {
        if (!_currentGrabable)
            return;
        _currentGrabable.transform.position = grabPoint.position;
    }

    private Grabable TryGetGrabable()
    {
        Collider2D col = Physics2D.OverlapCircle(grabPoint.position, grabRadius, grabableLayer);
        if (col != null)
            return col.GetComponent<Grabable>();
        return null;
    }

    public void Grab(bool isGrabbing)
    {
        print("Graber.Grab : " + isGrabbing);
        if (!isGrabbing)
        {
            _currentGrabable = null;
            return;
        }

        _currentGrabable = TryGetGrabable();
    }

    private void OnDrawGizmos()
    {
        if (!_debug) return;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(grabPoint.position, grabRadius);
    }
}
