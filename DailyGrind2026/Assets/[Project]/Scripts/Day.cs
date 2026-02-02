using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Day : MonoBehaviour
{
    private DayTime[] _dayTimeArray;
    private UnityEvent _onDayFinish = new UnityEvent();
    public UnityEvent OnDayFinishEvent => _onDayFinish;
    float _dayDuration;

    public float Init()
    {
        _dayTimeArray = GetComponentsInChildren<DayTime>();
        foreach (var item in _dayTimeArray)
        {
            _dayDuration += item.Init();
            item.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        return _dayDuration;
    }

    public void StartDayCoroutine()
    {
        StartCoroutine(DayLoopCoroutine());
    }

    private IEnumerator DayLoopCoroutine()
    {
        for (int i = 0; i < _dayTimeArray.Length - 1; i++)
        {
            _dayTimeArray[i].PlayDayTime();
            yield return new WaitForSeconds(_dayTimeArray[i].totalDuration);
        }
        _dayTimeArray[_dayTimeArray.Length - 1].PlayDayTime();
        yield return new WaitForSeconds(_dayTimeArray[_dayTimeArray.Length - 1].totalDuration);
        _onDayFinish.Invoke();
        yield return new WaitForSeconds(_dayTimeArray[_dayTimeArray.Length - 1].ExitClipDuration);
        gameObject.SetActive(false);
    }
}
