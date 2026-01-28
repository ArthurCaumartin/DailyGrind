using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;


public class Day : MonoBehaviour
{
    [SerializeField] private List<DayTime> _dayTimeList = new List<DayTime>();

    private float _duration;
    public float Duration => _duration;

    private void ComputeDuration()
    {
        _duration = 0;
        foreach (var item in _dayTimeList)
        {
            _duration += item.GetDuration();
        }
    }

    public IEnumerator PlayDay(float timeOffset)
    {
        // PlayHome();
        yield return new WaitForSeconds((_duration / 3) + timeOffset);
        // PlaySubway();
        // yield return new WaitForSeconds((_duration / 3) + timeOffset);
        // PlayWork();
        // yield return new WaitForSeconds((_duration / 3) + timeOffset);
    }

    // public void PlayHome()
    // {
    //     _subway.SetActive(false);
    //     _work.SetActive(false);
    // }

    // public void PlaySubway()
    // {
    //     _home.SetActive(false);
    //     _work.SetActive(false);
    // }

    // public void PlayWork()
    // {
    //     _subway.SetActive(false);
    //     _home.SetActive(false);
    // }
}
