using UnityEngine;


public class GameSequencer : MonoBehaviour
{
    [SerializeField] private DayBoucle _firstLoop;
    [SerializeField] private DayBoucle _secondLoop;
    [SerializeField] private DayBoucle _happyLoop;


    public void Start()
    {
        _firstLoop.StartBoucle(() =>
        {
            _secondLoop.StartBoucle(null);
        });
    }


}







