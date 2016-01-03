using UnityEngine;
using System.Collections;

public class TestOutput : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hello world!");
	}
	
	// Update is called once per frame
	void Update () {
	   
	}


    //float timer = 0f;
    void OnGUI()
    {
        //timer = Time.deltaTime;
        GUI.Label(new Rect(0, 0, 100, 100), "Time delta: " + Time.deltaTime.ToString());
    }
}
