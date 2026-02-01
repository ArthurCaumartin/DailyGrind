using UnityEngine;

public class Grabable : MonoBehaviour
{
    [SerializeField] private GrabableType _type;
    public bool isGrabbed;
    private Rigidbody2D _rigidbody;

    public GrabableType Type => _type;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Grab(Graber graber)
    {
        isGrabbed = true;
        _rigidbody.isKinematic = true;
    }

    public virtual void Release(Graber graber)
    {
        isGrabbed = false;
        _rigidbody.isKinematic = false;
        Collector collector = TryGetCollector();
        collector?.Collect(this);
    }

    protected Collector TryGetCollector()
    {
        if (this == null || gameObject == null)
            return null;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        if (cols.Length == 0) return null;
        for (int i = 0; i < cols.Length; i++)
        {
            Collector collector = cols[i].GetComponent<Collector>();
            if (collector)
                return collector;
        }
        return null;
    }
}
