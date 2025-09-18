using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Timer
{
    [SerializeField] private float _currentTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private bool _isRunning = true;
    [Space]
    [SerializeField] private UnityEvent _onTimerEndEvent;
    private Action _onTimerEndAction;

    public float TimeRatio => _currentTime / _maxTime;
    public float CurrentTime => _currentTime;
    public float MaxTime => _maxTime;

    public async void Start()
    {
        _currentTime = 0;
        while (_currentTime < _maxTime)
        {
            await Task.Yield();

            if (!_isRunning)
                continue;
            _currentTime += Time.deltaTime;
        }
        _onTimerEndAction?.Invoke();
        _onTimerEndEvent?.Invoke();
    }

    public void Reset()
    {
        _currentTime = 0;
    }

    public void Pause(bool isPaused)
    {
        _isRunning = !isPaused;
    }

    public Timer(float maxTime, Action onTimerEnd = null)
    {
        _maxTime = maxTime;
        _currentTime = 0;
        _onTimerEndAction = onTimerEnd;
    }
}