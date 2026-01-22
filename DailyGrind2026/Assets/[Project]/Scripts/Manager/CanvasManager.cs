using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] private Image _imageAplhaHider;
    // [SerializeField] private AnimationCurve _alphaHideCurve;
    [Space]
    [SerializeField] private Image _imageLeftHider;
    [SerializeField] private Image _imageRightHider;

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
}