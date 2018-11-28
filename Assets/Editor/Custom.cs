using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Custom : MonoBehaviour {

    [MenuItem("Custom/Mode/TestCustom",false,1)]
    static void Print()
    {
        Debug.Log("This is Custom Menu Clicked");
    }
}
