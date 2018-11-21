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

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool Ischeck = true;
            foreach (GameObject obj in ListUi)
            {
                if (obj.activeSelf == Ischeck)
                {
                    Ischeck = false;
                    obj.SetActive(Ischeck);
                    Time.timeScale = 1f;
                    break;
                }
            }
            if (Ischeck)
            {
                ListUi[0].SetActive(true); //Pause Menu
                Time.timeScale = 0f;
            }
        }

    }

    public void on_rejected_clicked()
    {
        ListUi[0].SetActive(false);
        Time.timeScale = 1f;
    }
}
