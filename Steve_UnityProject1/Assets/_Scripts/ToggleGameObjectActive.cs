using UnityEngine;
using System.Collections;

public class ToggleGameObjectActive : MonoBehaviour
{
    public GameObject toToggle;
    
    public void Toggle()
    {
        toToggle.SetActive(!toToggle.activeSelf);
    }
}
