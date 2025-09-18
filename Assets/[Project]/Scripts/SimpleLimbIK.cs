using System.Collections.Generic;
using System.Linq;
using Alchemy.Inspector;
using UnityEngine;


public class SimpleLimbIK : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform root;
    [SerializeField] private Transform target;
    [SerializeField] private Transform effector;
    [SerializeField, ReadOnly] private List<Transform> mid = new List<Transform>();
    private int _currentMidIndex;

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
        _lineRenderer.positionCount = mid.Count;
        for (int i = 0; i < mid.Count; i++)
            _lineRenderer.SetPosition(i, mid[i].position);
    }

    private void ResolveIK()
    {
        for (int i = 0; i < mid.Count; i++)
        {
            Vector2 dirPivotToEffector = effector.position - mid[i].position;
            dirPivotToEffector = dirPivotToEffector.normalized;

            Vector2 dirPivotToTarget = target.position - mid[i].position;
            dirPivotToTarget = dirPivotToTarget.normalized;

            float angle = Vector2.SignedAngle(dirPivotToEffector, dirPivotToTarget);
            angle *= Time.deltaTime * _speed;
            print("signAngl : " + angle);

            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward)
                                * mid[i].rotation;
            mid[i].rotation = newRot;
        }

        // _currentMidIndex++;
        // if (_currentMidIndex >= mid.Count)
        //     _currentMidIndex = 0;
    }
}