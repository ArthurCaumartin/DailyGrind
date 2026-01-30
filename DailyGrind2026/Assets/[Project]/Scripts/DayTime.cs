using System.Collections;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    [SerializeField] private float _duration = 2;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorMid;
    [SerializeField] private AnimationClip _enterClip;
    [SerializeField] private AnimationClip _midLoopClip;
    [SerializeField] private AnimationClip _exitClip;
    [HideInInspector] public float totalDuration;

    public float ExitClipDuration => _exitClip.length;

    private void Awake()
    {
        totalDuration = _enterClip.length + _duration;
        // if (_midLoopClip)
        //     totalDuration += _midLoopClip.length;
    }

    public void PlayDayTime()
    {
        gameObject.SetActive(true);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        _animator.Play("Enter");
        yield return new WaitForSeconds(_enterClip.length);
        _animatorMid.Play("Mid");
        yield return new WaitForSeconds(_duration);
        _animator.Play("Exit");
        yield return new WaitForSeconds(_exitClip.length + 1f);
        gameObject.SetActive(false);
    }
}