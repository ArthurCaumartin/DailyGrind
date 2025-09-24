using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Phase Data", menuName = "ScriptableObjects/PhaseData", order = 1)]
public class PhaseData : ScriptableObject
{
    public List<DayData> dayList;

    public float GetTotalDuration()
    {
        float totalDuration = 0;
        foreach (var day in dayList)
        {
            totalDuration += day.homeDuration + day.subwayDuration + day.workDuration;
        }
        return totalDuration;
    }
}



