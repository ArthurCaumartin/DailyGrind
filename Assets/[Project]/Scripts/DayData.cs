using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day Data", menuName = "ScriptableObjects/DayData", order = 1)]
public class DayData : ScriptableObject
{
    public int loopCount;
    public PhaseData[] phases;
}



