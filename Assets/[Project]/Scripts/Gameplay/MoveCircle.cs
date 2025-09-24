using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _amplitude = 2f;
    private Vector2 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Cos(Time.time * _speed) * _amplitude;
        float y = Mathf.Sin(Time.time * _speed) * _amplitude;
        transform.position = _startPos + new Vector2(x, y);
    }
}