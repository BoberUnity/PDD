using UnityEngine;

public class ButtonSpriteScale : MonoBehaviour{    [SerializeField] private UILabel label = null;
    private UISprite sprite = null;

    private void Awake()
    {
        sprite = GetComponent<UISprite>();
    }

    public void Resize()
    {
        sprite.height = label.height + 56;
    }}