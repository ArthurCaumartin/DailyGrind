using UnityEngine;


public class GameSequencer : MonoBehaviour
{
    [SerializeField] private DayBoucle _firstLoop;
    [SerializeField] private DayBoucle _secondLoop;
    [SerializeField] private DayBoucle _happyLoop;
    private float _totalDuration;

    public void Start()
    {
        CanvasManager.Instance.PanelAnimation(_firstLoop.duration, true);
        AudioManager.Instance.MusicPitchAnimation(_firstLoop.duration);
        _firstLoop.StartBoucle(() =>
        {
            print("sioerjiosefjiosefjosefjisefjio");
            CanvasManager.Instance.ShowChoice();
        });
    }


}







