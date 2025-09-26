using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private VisualSetter _visualSetter;
    [SerializeField] private PhaseManager _phaseManager;
    [Space]
    [SerializeField] private SimpleLimbIK _simpleLimbIK;
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _endSpeed;

    public List<PhaseData> phaseList;
    public int currentPhaseIndex;
    public bool IsGameplayEnabled = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _phaseManager.onPhaseEnded.AddListener(NextPhase);

        print("Game Start");
        _phaseManager.PlayPhase(phaseList[currentPhaseIndex]);

        float totalGameDuration = 0;
        foreach (var phase in phaseList)
            totalGameDuration += phase.GetTotalDuration();
        DOTween.To((time) =>
        {
            CanvasManager.Instance.HidePanelFill(time);
            _simpleLimbIK?.SetSpeed(time);
        }, 0, 0.6f, totalGameDuration).SetEase(Ease.Linear);
        AudioManager.Instance.MusicPitchAnimation(totalGameDuration);
    }

    public void NextPhase()
    {
        currentPhaseIndex++;
        if (currentPhaseIndex < phaseList.Count)
        {
            _phaseManager.PlayPhase(phaseList[currentPhaseIndex]);
            return;
        }

        print("Game Ended");
        CanvasManager.Instance.HideGame(true, 2);
    }
}
