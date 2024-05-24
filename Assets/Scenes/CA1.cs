using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CA1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IntCompare();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoopNums();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PrintHelloWorld();
        }
    }

    void IntCompare()
    {
        int a = 5;
        int b = 10;
        if (a == b)
        {
            Debug.Log("Both numbers are equal.");
        }
        else
        {
            Debug.Log("The numbers are not equal.");
            Debug.Log("The larger number is: " + Mathf.Max(a, b));
        }
    }

    void LoopNums()
    {
        string output = "";
        for (int i = 1; i <= 10; i++)
        {
            output += i + " ";
        }
        Debug.Log(output.Trim());
    }

    void PrintHelloWorld()
    {
        int count = 0;
        while (count < 10)
        {
            Debug.Log("Hello World");
            count++;
        }
    }
}