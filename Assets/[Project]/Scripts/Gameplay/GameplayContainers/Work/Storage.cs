using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private DocumentColor _acceptedColor;

    public void StoreDocument(GrabableDocument document)
    {
        if (document == null)
            return;
        if (document.DocumentColor != _acceptedColor)
            return;
        Destroy(document.gameObject);
    }
}