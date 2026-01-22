using System;
using UnityEngine;

[Serializable]
public enum DocumentColor
{
    Red,
    Blue,
}

public class GrabableDocument : Grabable
{
    [SerializeField] private DocumentColor documentColor;

    public DocumentColor DocumentColor => documentColor;

    public override void Release(Graber graber)
    {
        base.Release(graber);
        Storage storage = TryGetStorage();
        print("Try get storage : " + storage);
        storage?.StoreDocument(this);
    }

    protected Storage TryGetStorage()
    {
        if (this == null || gameObject == null)
            return null;
            
        Collider2D col = Physics2D.OverlapBox(transform.position, Vector2.one, 0, LayerMask.GetMask("Storage"));
        if (!col) return null;
        Storage storage = col.GetComponent<Storage>();
        return storage;
    }
}
