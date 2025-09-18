using System;
using UnityEngine;

[Serializable]
public class PhaseData
{
    [SerializeField] private float duration;
    [SerializeField] private Sprite spriteBackground;
    [SerializeField] private Sprite spritePlayer;

    public float Duration => duration;
    public Sprite SpriteBackground => spriteBackground;
    public Sprite SpritePlayer => spritePlayer;

}



