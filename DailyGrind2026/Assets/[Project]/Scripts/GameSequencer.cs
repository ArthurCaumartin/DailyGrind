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
            CanvasManager.Instance.ShowChoice();
        });
    }

    public void QuitJob()
    {
        CanvasManager.Instance.HideChoice();
        CanvasManager.Instance.PanelAnimation(1, false);
        _happyLoop.StartBoucle(null);
    }

    public void StayJob()
    {
        CanvasManager.Instance.HideChoice();
        CanvasManager.Instance.PanelAnimation(_firstLoop.duration, true);
        AudioManager.Instance.MusicPitchAnimation(_firstLoop.duration);
        _secondLoop.StartBoucle(null);
    }
}







