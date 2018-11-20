using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPanel : MonoBehaviour
{

    public List<GameObject> ListUi = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < ListUi.Count; i++)
        {
            Debug.Log(ListUi[i]);
            ListUi[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool Ischeck = true;
            //           Debug.Log("before "+Ischeck);
            foreach (GameObject obj in ListUi)
            {
                //               Debug.Log("middle " + obj.activeSelf);
                if (obj.activeSelf == Ischeck)
                {
                    Ischeck = false;
                    //                   Debug.Log("Last " +Ischeck);
                    obj.SetActive(Ischeck);
                    break;
                }
            }
            //            Debug.Log("PauseMenu before " + Ischeck);
            if (Ischeck)
            {
                //                Debug.Log("PauseMenu " + Ischeck);
                ListUi[0].SetActive(true); //Pause Menu
            }
        }

    }

    public void on_rejected_clicked()
    {
        ListUi[0].SetActive(false);
    }
}
