using UnityEngine;

public static class QuaternionUtils2D
{
    public static float SignedAngle(Quaternion a, Quaternion b)
    {
        float angleA = a.eulerAngles.z;
        float angleB = b.eulerAngles.z;

        return Mathf.DeltaAngle(angleA, angleB);
    }
}