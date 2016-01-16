using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeArtUIController_Final : MonoBehaviour
{
    public MeshRenderer artMeshRenderer;
    public Texture2D[] artImages;
    public EventSystem eventSystem;
    public Button leftButton;
    public Button rightButton;

    private int currentTextureIndex = 0;

    void Awake()
    {
        if (artMeshRenderer == null)
            throw new System.ArgumentNullException("artMaterial");

        if (artImages == null )
            throw new System.ArgumentNullException("artImages");

        SetImage();
    }

    void Update()
    {
        var pointerData = new PointerEventData(eventSystem);

        if (Input.GetKeyDown("joystick 1 button 4")) //left bumper
        {
            ExecuteEvents.Execute(leftButton.gameObject, pointerData, ExecuteEvents.submitHandler);
        }

        if (Input.GetKeyDown("joystick 1 button 5")) // right bumper
        {
            ExecuteEvents.Execute(rightButton.gameObject, pointerData, ExecuteEvents.submitHandler);
        }
    }

    public void NextImage()
    {
        currentTextureIndex++;
        if (currentTextureIndex >= artImages.Length)
            currentTextureIndex = 0;

        SetImage();
    }

    public void PrevImage()
    {
        currentTextureIndex--;
        if (currentTextureIndex < 0)
            currentTextureIndex = artImages.Length - 1;

        SetImage();
    }

    public void SetImage()
    {
        artMeshRenderer.material.mainTexture = artImages[currentTextureIndex];
    }
}
