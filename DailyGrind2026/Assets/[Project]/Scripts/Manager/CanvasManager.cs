using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] private Image _imageAplhaHider;
    [Space]
    [SerializeField] private Image _imageLeftHider;
    [SerializeField] private Image _imageRightHider;
    [SerializeField] private AnimationCurve _hideCurve;
    [Space]
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void HideGame(bool hide, float duration, Action toDoAfter = null)
    {
        if (duration == 0)
        {
            Color color = Color.black;
            color.a = hide ? 1 : 0;
            _imageAplhaHider.color = color;
            toDoAfter?.Invoke();
            return;
        }

        float _startAlpha = _imageAplhaHider.color.a;
        float _endAlpha = hide ? 1 : 0;
        Color newColor = _imageAplhaHider.color;
        DOTween.To((time) =>
        {
            newColor.a = Mathf.Lerp(_startAlpha, _endAlpha, time);
            _imageAplhaHider.color = newColor;
        }, 0, 1, duration)
        .SetEase(Ease.Linear)
        .OnComplete(() => toDoAfter?.Invoke());
    }

    public void HidePanelFill(float fillValue)
    {
        _imageLeftHider.fillAmount = fillValue;
        _imageRightHider.fillAmount = fillValue;
    }

    public void PanelAnimation(float duration, bool startOpen, Action after = null)
    {
        float start = startOpen ? 0 : 1;
        float end = startOpen ? 1 : 0;
        DOTween.To((time) =>
        {
            HidePanelFill(time);
        }, start, end, duration)
        .SetEase(_hideCurve)
        .OnComplete(() => after?.Invoke());
    }

    public void HideChoice()
    {
        DOTween.To((time) =>
        {
            _canvasGroup.alpha = 1 - time;
        }, 0, 1, 1);
    }

    public void ShowChoice()
    {
        _buttonYes.enabled = false;
        _buttonNo.enabled = false;
        DOTween.To((time) =>
        {
            _canvasGroup.alpha = time;
        }, 0, 1, 2)
        .OnComplete(() =>
        {
            _buttonYes.enabled = true;
            _buttonNo.enabled = true;
        });
    }
}