using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetButtonHighlightImage : MonoBehaviour
{
    public Sprite normal;
    public Sprite highlighted;
    public Sprite pressed;
    public Image thisImage;

    public void OnPointerEnter()
    {
        SetHighlight(ButtonState.highlighted);
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
        SetHighlight(ButtonState.highlighted);
    }




    enum ButtonState { normal, highlighted, pressed}
    
    void SetHighlight(ButtonState buttonState)
    {
        switch (buttonState)
        {
            case ButtonState.normal:
                thisImage.overrideSprite = normal;
                break;
            case ButtonState.highlighted:
                thisImage.overrideSprite = highlighted;
                break;
            case ButtonState.pressed:
                thisImage.overrideSprite = pressed;
                break;
            default:
                break;
        }
    }

}
