using UnityEngine;

public class GrabableGenetator : Grabable
{
    [SerializeField] private Grabable _grabablePrefab;
    public override void Release(Graber graber)
    {
        return;
    }

    public override void Grab(Graber graber)
    {
        Grabable newGrabable = Instantiate(_grabablePrefab);
        graber.SetGrabable(newGrabable);
    }
}