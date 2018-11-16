using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownUI : MonoBehaviour {

    public Dropdown Box;
    List<string> options = new List<string>();

	// Use this for initialization
	void Start () {
        Box.gameObject.SetActive(false);

        for (int i = 0; i < 100; i ++)
        {
            options.Add("" + i);
        }

        Box.AddOptions(options);
        Box.value = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (Box.value == 1)
            Debug.Log("1111111");
        else if (Box.value == 2)
            Debug.Log("2222222");


    }
}
