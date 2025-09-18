using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private DayLooper _dayLooper;
    [SerializeField] private List<DayData> _daysDataList;




    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        CanvasManager.Instance.HideGame(true, 0, () =>
        {
            CanvasManager.Instance.HideGame(false, 1);
        });
    }
    
}
