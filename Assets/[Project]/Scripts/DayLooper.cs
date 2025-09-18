using UnityEngine;

public class DayLooper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backgroundRenderer;
    [SerializeField] private SpriteRenderer _playerRenderer;

    private DayData _currentDayData;
    private int _currentLoop = 0;
    private int _currentPhaseIndex = 0;
    [SerializeField] private float _phaseTimer = 0f;

    public void SetDayData(DayData dayData)
    {
        _currentDayData = dayData;
        _currentLoop = 0;

        StartNextPhase();
    }

    private void StartNextPhase()
    {
        
    }
}