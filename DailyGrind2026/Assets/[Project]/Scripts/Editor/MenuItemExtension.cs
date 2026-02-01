using UnityEngine;
using UnityEditor;

public class MenuItemExtension
{
    [MenuItem("CONTEXT/Transform/MicroLabGames/Set Child Sprite Order With Axis Z")]
    public static void SetSpriteOrderOnAxisZ(MenuCommand command)
    {
        Transform transform = (Transform)command.context;
        SpriteRenderer[] spArray = transform.GetComponentsInChildren<SpriteRenderer>();
        Undo.RecordObjects(spArray, "Sprite Order");

        if (spArray.Length == 0) return;
        for (int i = 0; i < spArray.Length; i++)
        {
            spArray[i].sortingOrder = -(int)(spArray[i].transform.position.z * 100);
        }
    }
}
