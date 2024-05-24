using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    string helloString = "hello world, i'm a string";
    int x = 2;
    int y = 5;
    bool demoBool = false;


    void HelloWorld()
    {
        // && check both side to be true to pass
        if (x <= y && demoBool)
        {
            Debug.Log(helloString);
        }
        Debug.Log(x);
        // same as x = x + y
        x += y;
        Debug.Log(x);
    }
    void Start()
    {
        HelloWorld();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
