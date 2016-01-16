using UnityEngine;
using System.Collections;
using System;

public class InputDetector : MonoBehaviour
{
    public enum TestType { joystickButtons, keys, axis, mouse, touch}
    public TestType testType = TestType.joystickButtons;
    public bool logMessages = true;

    int maxJoystickNum = 100;
    int maxButtonNum = 100;
    string testString = "";

    void Update()
    {
        switch (testType)
        {
            case TestType.joystickButtons:
                TestJoystickButtons();
                break;
            case TestType.keys:
                TestKeyCodes();
                break;
            case TestType.axis:
                TestAxis();
                break;
            case TestType.mouse:
                TestMouse();
                break;
            case TestType.touch:
                TestTouch();
                break;
            default:
                testString = "No test selected.";
                break;
        }
    }

    private void TestTouch()
    {
        
    }

    private void TestMouse()
    {
        
    }

    void TestJoystickButtons()
    {
        SetMaxJoystickNum();
        SetMaxJoystickButtonNum();

        string tag = "TestJoystickButtons: \n";
        for (int j = 1; j <= maxJoystickNum; j++)
        {
            for (int i = 0; i <= maxButtonNum; i++)
            {
                string joystickButton = "joystick " + j.ToString() + " button " + i.ToString();
                //joystick 1 button 0
                try
                {
                    if (Input.GetKeyDown(joystickButton))
                    {
                        testString = tag + joystickButton;
                        Log(testString);
                    }
                }
                catch (System.ArgumentException e)
                {
                    maxButtonNum = i - 1;
                    Debug.LogWarningFormat("max joystick button number found: {0}\n{1}", maxButtonNum, e);
                    break;
                }
            }
        }
    }

    void SetMaxJoystickNum()
    {
        if (maxJoystickNum != 100)
            return;

        for (int i = 1; i <= maxJoystickNum; i++)
        {
            string joystickButton = "joystick " + i.ToString() + " button 0";
            try
            {
                if (Input.GetKeyDown(joystickButton))
                {
                    //do nothing
                }
            }
            catch (System.ArgumentException e)
            {
                maxJoystickNum = i - 1;
                Debug.LogWarningFormat("max joystick number found: {0}\n{1}", maxJoystickNum, e);
                break;
            }
        }
    }

    void SetMaxJoystickButtonNum()
    {
        if (maxButtonNum != 100)
            return;
        int j = 1;

        for (int i = 0; i <= maxButtonNum; i++)
        {
            string joystickButton = "joystick " + j.ToString() + " button " + i.ToString();
            try
            {
                if (Input.GetKeyDown(joystickButton))
                {
                    testString = tag + joystickButton;
                    Log(testString);
                }
            }
            catch (System.ArgumentException e)
            {
                maxButtonNum = i - 1;
                Debug.LogWarningFormat("max joystick button number found: {0}\n{1}", maxButtonNum, e);
                break;
            }
        }
    }

    void TestKeyCodes()
    {
        string tag = "TestKeyCodes: \n";

        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode) && keyCode != KeyCode.None)
            {
                testString = tag + keyCode.ToString();
                Log(testString);
            }
        }
    }

    
    void TestAxis()
    {
        string tag = "TestAxis: \n";

        float h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(h) > 0.001f)
        {
            testString = tag + "Horizontal " + h.ToString();
        }

        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(v) > 0.001f)
        {
            testString = tag + "Vertical " + v.ToString();
        }

        for (int i = 3; i <= 14 ; i++)
        {
            string axis = "axis " + i.ToString();
            float value = Input.GetAxis(axis);
            if (Mathf.Abs(value) > 0.001f)
            {
                testString = tag + axis + " " + value.ToString();
            }
        }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 500), testString);
    }

    void Log(string message)
    {
        if (!logMessages)
            return;

        Debug.Log(message);
    }
}
