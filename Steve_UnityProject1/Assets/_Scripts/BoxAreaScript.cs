using UnityEngine;
using System.Collections;

public class BoxAreaScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject topWall;

    void Start()
    {
        foreach (Transform trans in gameObject.transform)
        {
            Debug.Log("name: " + trans.name);
        }
    }

    void Update()
    {

    }
}
