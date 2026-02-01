using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeReference] private GrabableType _expectedType;

    public void Collect(Grabable grabable)
    {
        if (grabable.Type == _expectedType)
        {
            Destroy(grabable.gameObject);
        }
    }
}
