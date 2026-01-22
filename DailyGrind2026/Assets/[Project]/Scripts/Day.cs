using System.Collections.Generic;
using UnityEngine;



public class Day : MonoBehaviour
{
    [SerializeField] private float _duration = 3f;

    [SerializeField] private GameObject _home;
    [SerializeField] private GameObject _subway;
    [SerializeField] private GameObject _work;


    public float Duration => _duration;

    public void PlayDay(float timeOffset)
    {
        
    }

    public void PlayHome()
    {
        _subway.SetActive(false);
        _work.SetActive(false);
    }

    public void PlaySubway()
    {
        _home.SetActive(false);
        _work.SetActive(false);
    }

    public void PlayWork()
    {
        _subway.SetActive(false);
        _home.SetActive(false);
    }
}



