using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    [SerializeField] private float _startPitch = 1.2f;
    [SerializeField] private float _endPitch = 0.5f;
    [SerializeField] private AudioSource _musicSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void MusicPitchAnimation(float duration)
    {
        DOTween.To((time) =>
        {
            _musicSource.pitch = time;
        }, _startPitch, _endPitch, duration).SetEase(Ease.Linear);
    }

}