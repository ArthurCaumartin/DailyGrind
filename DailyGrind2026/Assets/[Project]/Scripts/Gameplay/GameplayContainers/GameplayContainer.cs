using UnityEngine;

public class GameplayContainer : MonoBehaviour
{
    public virtual void EnableGameplay(bool isGameplayEnabled)
    {
        gameObject.SetActive(isGameplayEnabled);
    }
}
