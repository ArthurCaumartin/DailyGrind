using UnityEngine;

public class Grabable : MonoBehaviour
{
    public bool isGrabbed;

    public virtual void Update()
    {

    }

    public virtual void Grab(Graber graber)
    {
        isGrabbed = true;
    }

    public virtual void Release(Graber graber)
    {
        isGrabbed = false;
    }
}
