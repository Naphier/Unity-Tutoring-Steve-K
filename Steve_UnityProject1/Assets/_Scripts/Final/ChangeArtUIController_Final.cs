using UnityEngine;
using System.Collections;

public class ChangeArtUIController_Final : MonoBehaviour
{
    public MeshRenderer artMeshRenderer;
    public Texture2D[] artImages;

    private int currentTextureIndex = 0;

    void Awake()
    {
        if (artMeshRenderer == null)
            throw new System.ArgumentNullException("artMaterial");

        if (artImages == null )
            throw new System.ArgumentNullException("artImages");

        SetImage();
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
