using System.Collections.Generic;
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
    [SerializeField] private float _rootMinAngle = 15f;
    [SerializeField] private float _rootMaxAngle = 160f;
    [Space]
    [SerializeField] private float _midMinAngle = 15f;
    [SerializeField] private float _midMaxAngle = 160f;
    [Space]
    [SerializeField] private List<Transform> mid = new List<Transform>();
    private bool _isIKEnabled = true;

    private void OnValidate()
    {
        // mid = root.GetComponentsInChildren<Transform>().ToList();
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
            float targetToEffectorDistance = Vector2.Distance(target.position, effector.position);

            // print("Dis : " + targetToEffectorDistance);
            Vector2 dirPivotToEffector = (effector.position - mid[i].position).normalized;
            Vector2 dirPivotToTarget = (target.position - mid[i].position).normalized;

            float angle = Vector2.SignedAngle(dirPivotToEffector, dirPivotToTarget);
            angle *= Time.deltaTime * _speed;
            
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward) * mid[i].rotation;

            if (i == 0)
            {
                Quaternion up = Quaternion.Euler(Vector3.zero);
                float rootAngle = QuaternionUtils2D.SignedAngle(up, newRot);
                if (rootAngle < _rootMinAngle || rootAngle > _rootMaxAngle)
                    continue;
            }

            if (i > 0)
            {
                float midAngle = QuaternionUtils2D.SignedAngle(mid[i - 1].rotation, newRot);
                if (midAngle < _midMinAngle || midAngle > _midMaxAngle)
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

    private void OnDrawGizmos()
    {
        if (mid.Count < 2) return;
        Gizmos.color = Color.red;
        for (int i = 1; i < mid.Count; i++)
        {
            Gizmos.DrawLine(mid[i - 1].position, mid[i].position);
        }
    }
}
