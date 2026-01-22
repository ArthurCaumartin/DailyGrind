using System;
using UnityEngine;

[Serializable]
public class DayData
{
    public int loopCount;
    [Space]
    public Sprite playerSprite;

    [Header("Home : ")]
    public float homeDuration;
    public Sprite backgroundHomeSprite;

    [Header("Sunway : ")]
    public float subwayDuration;
    public Sprite backgroundSubwaySprite;

    [Header("Work : ")]
    public float workDuration;
    public Sprite backgroundWorkSprite;
    
}



