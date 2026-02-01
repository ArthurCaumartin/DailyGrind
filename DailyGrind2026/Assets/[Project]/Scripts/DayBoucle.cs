using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DayBoucle : MonoBehaviour
{
    [SerializeField] private Sprite _playerSpriteToSet;
    private List<Day> _dayList = new List<Day>();
    public Action _toDoWhenBoucleEnd;

    private void Awake()
    {
        _dayList = GetComponentsInChildren<Day>().ToList();
        foreach (var item in _dayList)
            item.Init();
    }

    public void StartBoucle(Action toDoAfter)
    {
        _toDoWhenBoucleEnd = toDoAfter;
        PlayDay(0);
    }

    private void PlayDay(int indexToPlay)
    {
        PlayerManager.Instance.SetPlayerSprite(_playerSpriteToSet);

        // print("Call index : " + indexToPlay);
        Day currentDay = _dayList[indexToPlay];
        currentDay.gameObject.SetActive(true);
        currentDay.StartDayCoroutine();

        if (indexToPlay >= _dayList.Count - 1)
        {
            // print("Last Day !");
            currentDay.OnDayFinishEvent.AddListener(() =>
            {
                _toDoWhenBoucleEnd?.Invoke();
                gameObject.SetActive(false);
            });
            return;
        }

        currentDay.OnDayFinishEvent.AddListener(() =>
        {
            PlayDay(indexToPlay + 1);
        });
    }
}
