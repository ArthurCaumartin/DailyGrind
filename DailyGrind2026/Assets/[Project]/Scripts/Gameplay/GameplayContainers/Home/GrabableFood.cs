using UnityEngine;

public class GrabableFood : GrabableDocument
{

    public override void Update()
    {
        // print("GrabableFood Update");
        Storage storage = TryGetStorage();
        if (storage)
            storage.StoreDocument(this);
    }
}