using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private VisualSetter _visualSetter;
    [Space]
    [SerializeField] private SimpleLimbIK _simpleLimbIK;
    [SerializeField] private GameplayContainer _gameplayHome;
    [SerializeField] private GameplayContainer _gameplayWork;

    private PhaseData _currentPhaseData;
    private DayData _currentDayData;
    private int _currentDayIndex;

    public UnityEvent onPhaseEnded;

    public void PlayPhase(PhaseData phaseData)
    {
        _currentPhaseData = phaseData;
        _currentDayIndex = 0;
        _currentDayData = phaseData.dayList[_currentDayIndex];
        StartCoroutine(PlayDay(_currentDayData));
    }

    private IEnumerator PlayDay(DayData dayData)
    {
        _visualSetter.SetPlayer(dayData.playerSprite);

        print("Home Phase");
        GameManager.Instance.IsGameplayEnabled = true;
        _visualSetter.SetBackground(dayData.backgroundHomeSprite);
        _gameplayWork.EnableGameplay(false);
        _gameplayHome.EnableGameplay(true);
        yield return new WaitForSeconds(dayData.homeDuration);


        print("Subway Phase");
        GameManager.Instance.IsGameplayEnabled = false;
        _visualSetter.SetBackground(dayData.backgroundSubwaySprite);
        _gameplayHome.EnableGameplay(false);
        _gameplayWork.EnableGameplay(false);
        yield return new WaitForSeconds(dayData.subwayDuration);


        print("Work Phase");
        GameManager.Instance.IsGameplayEnabled = true;
        _visualSetter.SetBackground(dayData.backgroundWorkSprite);
        _gameplayHome.EnableGameplay(false);
        _gameplayWork.EnableGameplay(true);
        yield return new WaitForSeconds(dayData.workDuration);

        _gameplayWork.EnableGameplay(false);
        GameManager.Instance.IsGameplayEnabled = false;
        NextDay();
    }

    private void NextDay()
    {
        _currentDayIndex++;
        if (_currentDayIndex < _currentPhaseData.dayList.Count)
        {
            _currentDayData = _currentPhaseData.dayList[_currentDayIndex];
            StartCoroutine(PlayDay(_currentDayData));
            return;
        }

        print("Phase Ended");
        onPhaseEnded?.Invoke();
    }
}
