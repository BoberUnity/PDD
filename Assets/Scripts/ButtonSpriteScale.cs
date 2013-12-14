using UnityEngine;

public class ButtonSpriteScale : MonoBehaviour
    private UISprite sprite = null;

    private void Awake()
    {
        sprite = GetComponent<UISprite>();
    }

    public void Resize()
    {
        sprite.height = label.height + 56;
    }