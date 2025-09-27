using System;
using DG.Tweening;
using UnityEngine;

public class VisualSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
    [SerializeField] private SpriteRenderer _deskSpriteRenderer;
    [SerializeField] private SpriteRenderer _transitionSpriteRenderer;

    private void Start()
    {
        Vector3 botLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        botLeft.z = 0;
        _backgroundSpriteRenderer.transform.position = botLeft;
        _transitionSpriteRenderer.sprite = null;
    }

    public void SetPlayer(Sprite sprite)
    {
        if (!sprite) return;
        _playerSpriteRenderer.sprite = sprite;
    }

    public void SetBackground(Sprite sprite, Action onComplete = null)
    {
        if (!sprite) return;
        BackAnimation(sprite, onComplete);
    }

    public void SetDesk(Sprite sprite)
    {
        if (!sprite) return;
        _deskSpriteRenderer.sprite = sprite;
    }

    private void BackAnimation(Sprite sprite, Action onComplete = null)
    {
        Vector3 botLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        botLeft.z = 0;

        Vector3 botRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0));
        botRight.z = 0;

        _transitionSpriteRenderer.transform.position = botRight;
        _transitionSpriteRenderer.sprite = sprite;
        DOTween.To((time) =>
        {
            Vector3 pos = Vector3.Lerp(botRight, botLeft, time);
            _transitionSpriteRenderer.transform.position = pos;
        }, 0, 1, 1)
        .OnComplete(() =>
        {
            _backgroundSpriteRenderer.sprite = sprite;
            _transitionSpriteRenderer.transform.position = botRight;
            onComplete?.Invoke();
        });
    }
}