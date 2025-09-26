using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DocumentGenerator : Grabable
{
    [SerializeField] private List<Grabable> _documentToSpawn;

    public override void Grab(Graber graber)
    {
        Grabable newGrabable = Instantiate(_documentToSpawn[Random.Range(0, _documentToSpawn.Count)]);
        graber.SetGrabable(newGrabable);
    }
}