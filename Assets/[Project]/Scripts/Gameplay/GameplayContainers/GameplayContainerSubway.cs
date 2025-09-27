using System.Collections.Generic;
using UnityEngine;

public class GameplayContainerSubway : GameplayContainer
{
    [SerializeField] private List<AnimationControler> _animatorTriggers;

    public void EnableGameplayWithDuration(bool isGameplayEnabled, float duration)
    {
        base.EnableGameplay(isGameplayEnabled);
        if (isGameplayEnabled)
        {
            foreach (var item in _animatorTriggers)
                item.TriggerAnimation(duration);
        }
    }
}
