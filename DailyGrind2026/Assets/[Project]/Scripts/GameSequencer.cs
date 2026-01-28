using System.Collections;
using UnityEngine;

public class GameSequencer : MonoBehaviour
{
    private Day[] _dayArray;
    private float _totalDuration;

    private void Start()
    {
        _dayArray = GetComponentsInChildren<Day>();
        if (_dayArray != null && _dayArray.Length > 0)
        {
            foreach (var item in _dayArray)
            {
                _totalDuration += item.Duration;
            }
        }

        StartCoroutine(Seqence());
    }

    private IEnumerator Seqence()
    {
        for (int i = 0; i < _dayArray.Length; i++)
        {
            _dayArray[i].PlayDay(0.5f);
            yield return new WaitForSeconds(_dayArray[i].Duration);
        }
    }
}
