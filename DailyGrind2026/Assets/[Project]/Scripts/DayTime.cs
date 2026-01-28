using UnityEngine;

public class DayTime : MonoBehaviour
{
    [SerializeField, Tooltip("Dur = enterAnim + duration + exitAnim")] private float _duration;
    [Space]
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _enterClip;
    [SerializeField] private AnimationClip _midLoopClip;
    [SerializeField] private AnimationClip _exitClip;

    public float GetDuration()
    {
        float inOutAnimDuration = 0;
        if (_enterClip)
            inOutAnimDuration += _enterClip.length;
        if (_exitClip)
            inOutAnimDuration += _enterClip.length;

        return _duration + inOutAnimDuration;
    }
}