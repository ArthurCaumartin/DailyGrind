using System.Linq;
using DG.Tweening;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    [SerializeField] private bool _playReverse = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _clipName = "clip";
    [SerializeField] private string _stateName = "state";
    [SerializeField] private float _clipDuration = 1f;

    public void TriggerAnimation(float reverseDelay = 0)
    {
        DOTween.To((time) =>
        {
            _animator.Play(_stateName, 0, time);
        }, 0, 1, _clipDuration);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (!_animator) return;

        RuntimeAnimatorController ac = _animator.runtimeAnimatorController;
        if (!ac)
        {
            Debug.LogWarning("No Animator Controller found on " + gameObject.name);
            return;
        }
        AnimationClip clip = ac.animationClips.ToList().Find(c => c.name == _clipName);
        _clipDuration = clip?.length ?? 1f;
    }
}