using UnityEngine;
using System.Collections;

public class DatabaseTest : MonoBehaviour
{
    public string[] wordsToTest;
    void Start()
    {
        foreach (string word in wordsToTest)
        {
            if (DBController.instance.IsWordValid(word))
                Debug.Log(word + " found");
            else
                Debug.LogError(word + " not found");
        }

        //DBController.instance.DumpDB("test.sqlite");
    }

    void Update()
    {

    }
}
