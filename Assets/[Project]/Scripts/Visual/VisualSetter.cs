using UnityEngine;

public class VisualSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
    [SerializeField] private SpriteRenderer _deskSpriteRenderer;

    public void SetPlayer(Sprite sprite)
    {
        _playerSpriteRenderer.sprite = sprite;
    }

    public void SetBackground(Sprite sprite)
    {
        _backgroundSpriteRenderer.sprite = sprite;
    }

    public void SetDesk(Sprite sprite)
    {
        _deskSpriteRenderer.sprite = sprite;
    }
}