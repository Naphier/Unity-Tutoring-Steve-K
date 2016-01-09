using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArtUITriggerController_Final : MonoBehaviour
{
    public CanvasGroup uiToControl;
    public float fadeDuration = 1f;

    enum State { none, fadeIn, fadeOut}
    State state = State.none;

    void Start()
    {
        if (uiToControl == null)
            throw new System.ArgumentNullException("uiControl");

        uiToControl.gameObject.SetActive(false);
        uiToControl.alpha = 0f;
    }


    float timer = 0f;
    void Update()
    {
        float time,a; 
        switch (state)
        {
            case State.none:
                timer = Time.time;
                break;
            case State.fadeIn:
                if (uiToControl.alpha < 1f)
                {
                    time = Time.time - timer;
                    a = Mathf.Lerp(0f, 1f, time / fadeDuration);
                    uiToControl.gameObject.SetActive(true);
                    uiToControl.alpha = a;
                    if (time >= fadeDuration)
                    {
                        state = State.none;
                    }
                }
                break;
            case State.fadeOut:
                if (uiToControl.alpha > 0f)
                {
                    time = Time.time - timer;
                    a = Mathf.Lerp(1f, 0f, time / fadeDuration);
                    uiToControl.alpha = a;
                    if (time >= fadeDuration)
                    {
                        uiToControl.gameObject.SetActive(false);
                        state = State.none;
                    }
                }
                break;
            default:
                break;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            timer = Time.time;
        }

        Debug.Log("OTE: " + other.gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            state = State.fadeIn;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            timer = Time.time;
            state = State.fadeOut;
        }
    }
}
