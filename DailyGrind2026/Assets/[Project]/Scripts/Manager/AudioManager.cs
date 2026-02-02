using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    [SerializeField] private float _startPitch = 1.2f;
    [SerializeField] private float _endPitch = 0.5f;
    [SerializeField] private AudioSource _musicSource;

    // [SerializeField] public AudioClip homeAmbiance;
    // [SerializeField] public AudioClip subwayAmbiance;
    // [SerializeField] public AudioClip workAmbiance;

    [SerializeField] private AudioSource _source1;
    [SerializeField] private AudioSource _source2;

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

    public void SwapAmbiance(AudioClip clip)
    {
        if (!clip) return;
        AudioSource toPlay = _source1.isPlaying ? _source2 : _source1;
        AudioSource toMute = _source1.isPlaying ? _source1 : _source2;
        toPlay.clip = clip;

        DOTween.To((time) =>
        {
            toPlay.volume = time;
            toMute.volume = 1 - time;
        }, 0, 1, 1)
        .OnComplete(() =>
        {
            toMute.Stop();
        });
    }

}