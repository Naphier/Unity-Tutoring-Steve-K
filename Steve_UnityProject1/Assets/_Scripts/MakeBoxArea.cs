using UnityEngine;
using System.Collections;

public class MakeBoxArea : MonoBehaviour
{
    public GameObject boxArea;
    void Start()
    {
        GameObject newBoxArea = GameObject.Instantiate(boxArea);
        newBoxArea.name = "This is my new box area";
    }

    void Update()
    {

    }
}
