using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SetButtonHighlight : MonoBehaviour
{
    public Sprite normal;
    public Sprite highlighted;
    public Sprite pressed;
    public Image thisImage;

    public void OnPointerEnter()
    {
        SetHighlight(ButtonState.hover);
    }

    public void OnPointerExit()
    {
        SetHighlight(ButtonState.normal);
    }

    public void OnPointerDown()
    {
        SetHighlight(ButtonState.pressed);
    }

    public void OnPointerUp()
    {
        SetHighlight(ButtonState.hover);
    }

    enum ButtonState { normal, hover, pressed}
    void SetHighlight(ButtonState buttonState)
    {
        switch (buttonState)
        {
            case ButtonState.normal:
                thisImage.overrideSprite = normal;
                break;
            case ButtonState.hover:
                thisImage.overrideSprite = highlighted;
                break;
            case ButtonState.pressed:
                thisImage.overrideSprite = pressed;
                break;
            default:
                thisImage.overrideSprite = normal;
                break;
        }
    }
}
