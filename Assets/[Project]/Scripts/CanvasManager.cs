using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    public Image _imageAplhaHider;
    public Image _imageLeftHider;
    public Image _imageRightHider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void HideGame(bool hide, float duration, Action toDoAfter = null)
    {
        float _startAlpha = _imageAplhaHider.color.a;
        float _endAlpha = hide ? 1 : 0;
        Color newColor = _imageAplhaHider.color;
        DOTween.To((time) =>
        {
            newColor.a = Mathf.Lerp(_startAlpha, _endAlpha, time);
            _imageAplhaHider.color = newColor;
        }, 0, 1, duration)
        .OnComplete(() => toDoAfter?.Invoke());
    }

    public void HidePanelFill(float fillValue)
    {
        _imageLeftHider.fillAmount = fillValue;
        _imageRightHider.fillAmount = fillValue;
    }
}