using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPanel : MonoBehaviour {

    public List<GameObject> ListUi = new List<GameObject>();
    public Canvas MainUi;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < ListUi.Count; i++)
        {
            ListUi[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            bool Ischeck = true;
            foreach(GameObject obj in ListUi)
            {
                if (obj.activeSelf == Ischeck)
                {
                    Ischeck = false;
                    obj.SetActive(Ischeck);
                    break;
                }   
            }
            if (Ischeck)
            {
                ListUi[0].SetActive(true); //Pause Menu
            }
        }
        
	}
}
