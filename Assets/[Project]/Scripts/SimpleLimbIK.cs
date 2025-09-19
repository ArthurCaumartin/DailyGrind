using System.Collections.Generic;
using System.Linq;
using Alchemy.Inspector;
using UnityEngine;

public class SimpleLimbIK : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform root;
    [SerializeField] private Transform target;
    [SerializeField] private Transform effector;
    [Space]
    [SerializeField] private float _minAngle = 15f;
    [SerializeField] private float _maxAngle = 160f;
    [Space]
    [SerializeField, ReadOnly] private List<Transform> mid = new List<Transform>();

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
        for (int i = 0; i < mid.Count; i++)
        {
            Vector2 dirPivotToEffector = effector.position - mid[i].position;
            dirPivotToEffector = dirPivotToEffector.normalized;
            Debug.DrawRay(mid[i].position, dirPivotToEffector, Color.red);

            Vector2 dirPivotToTarget = target.position - mid[i].position;
            dirPivotToTarget = dirPivotToTarget.normalized;
            Debug.DrawRay(mid[i].position, dirPivotToTarget, Color.green);

            float angle = Vector2.SignedAngle(dirPivotToEffector, dirPivotToTarget);
            angle *= Time.deltaTime * _speed;
            // print("signAngl : " + angle);

            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward)
                                * mid[i].rotation;

            if (i > 0)
            {
                float midAngle = QuaternionUtils2D.SignedAngle(mid[i - 1].rotation, newRot);
                // print($"midAngle | {mid[i - 1].name} | {mid[i].name} : " + midAngle);
                if (midAngle < _minAngle || midAngle > _maxAngle)
                    continue;
            }

            mid[i].rotation = newRot;
        }
    }
}




public static class QuaternionUtils2D
{
    public static float SignedAngle(Quaternion a, Quaternion b)
    {
        float angleA = a.eulerAngles.z;
        float angleB = b.eulerAngles.z;

        return Mathf.DeltaAngle(angleA, angleB);
    }
}