using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class Day : MonoBehaviour
{
    private DayTime[] _dayTimeArray;
    private UnityEvent _onDayFinish = new UnityEvent();
    public UnityEvent OnDayFinishEvent => _onDayFinish;

    public void Init()
    {
        _dayTimeArray = GetComponentsInChildren<DayTime>();
        foreach (var item in _dayTimeArray)
            item.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    public void StartDayCoroutine()
    {
        StartCoroutine(DayLoopCoroutine());
    }

    private IEnumerator DayLoopCoroutine()
    {
        for (int i = 0; i < _dayTimeArray.Length; i++)
        {
            _dayTimeArray[i].PlayDayTime();
            float endAnimDuration = i == _dayTimeArray.Length - 1 ? _dayTimeArray[i].ExitClipDuration : 0;
            yield return new WaitForSeconds(_dayTimeArray[i].totalDuration + endAnimDuration);
        }
        _onDayFinish.Invoke();
    }
}
