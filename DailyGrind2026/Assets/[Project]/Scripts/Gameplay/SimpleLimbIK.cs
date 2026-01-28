using System.Collections.Generic;
using System.Linq;
using Alchemy.Inspector;
using UnityEngine;

public class SimpleLimbIK : MonoBehaviour
{
    [SerializeField] private Transform _resetTargetTransform;
    [Header("Speed")]
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _startSpeed = 5;
    [SerializeField] private float _endSpeed = 1;
    [Header("References")]
    [SerializeField] private Transform root;
    [SerializeField] private Transform target;
    [SerializeField] private Transform effector;
    [Header("Constraints")]
    [SerializeField] private bool _flip;
    [SerializeField] private float _minAngle = 15f;
    [SerializeField] private float _maxAngle = 160f;
    [Space]
    [SerializeField, ReadOnly] private List<Transform> mid = new List<Transform>();
    private bool _isIKEnabled = true;

    private void OnValidate()
    {
        mid = root.GetComponentsInChildren<Transform>().ToList();
    }

    private void Start()
    {
        OnValidate();
    }

    private void Update()
    {
        ResolveIK();
    }

    private void ResolveIK()
    {
        if (!_isIKEnabled)
            return;

        for (int i = 0; i < mid.Count; i++)
        {
            Vector2 dirPivotToEffector = (effector.position - mid[i].position).normalized;
            Vector2 dirPivotToTarget = (target.position - mid[i].position).normalized;

            float angle = Vector2.SignedAngle(dirPivotToEffector, dirPivotToTarget);
            if (_flip)
                angle = -angle;

            angle *= Time.deltaTime * _speed;

            Quaternion newRot =
                Quaternion.AngleAxis(angle, Vector3.forward) * mid[i].rotation;

            if (i > 0)
            {
                float midAngle =
                    QuaternionUtils2D.SignedAngle(mid[i - 1].rotation, newRot);

                if (midAngle < _minAngle || midAngle > _maxAngle)
                    continue;
            }

            mid[i].rotation = newRot;
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        target.position = position;
    }

    public void EnableIK(bool isEnabled)
    {
        _isIKEnabled = isEnabled;
    }

    public void SetSpeed(float t)
    {
        _speed = Mathf.Lerp(_startSpeed, _endSpeed, t);
    }
}
