using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] private SpriteRenderer _playerRederer;
    [SerializeField] private Sprite _playerDeaultSprite;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPlayerSprite(Sprite sprite)
    {
        if (!sprite)
        {
            _playerRederer.sprite = _playerDeaultSprite;
            return;
        }
        _playerRederer.sprite = sprite;
    }
}