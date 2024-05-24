using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2 : MonoBehaviour
{
	int a = 3;
	int x = 6;
	int y = 4;
	


	void QuickMath()
	{
		if ( x > a)
		{
			a = a + y;
			if ( a > x)
			{
				string aBigger = "x is not the biggest number";
				Debug.Log(aBigger);


			}
			else if ( a < x)
			{
				string aSmaller= "x is the biggest number";
				Debug.Log(aSmaller);


			}
		}

	}

	void Start()
	{
		QuickMath();
	}
}