using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayBoucle : MonoBehaviour
{
    [SerializeField] private UnityEvent _onBoucleFinish;
    [SerializeField] public List<Day> _dayList = new List<Day>();

    private void Start()
    {
        _dayList.RemoveAll(obj => obj == null);
        foreach (var item in _dayList)
            item.gameObject.SetActive(false);
        PlayDay(0);
    }

    public void PlayDay(int indexToPlay)
    {
        print("Call index : " + indexToPlay);
        Day currentDay = _dayList[indexToPlay];
        currentDay.gameObject.SetActive(true);
        currentDay.StartDayCoroutine();

        if (indexToPlay >= _dayList.Count - 1)
        {
            print("Last Day !");
            currentDay.OnDayFinishEvent.AddListener(() => _onBoucleFinish.Invoke());
            return;
        }

        currentDay.OnDayFinishEvent.AddListener(() =>
        {
            _dayList[indexToPlay].gameObject.SetActive(false);
            PlayDay(indexToPlay + 1);
            print("soeifh");
        });
    }
}
