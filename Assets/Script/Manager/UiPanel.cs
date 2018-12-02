using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eTypeUi
{
    eType_MessageBox = 0,
    eType_Shop = 1,
    eType_End,
}

public class UiPanel : MonoBehaviour
{
    public List<GameObject> ListUi = new List<GameObject>();
    private static UiPanel _instance = null;
    bool m_CheckInfoActive = false;
    public static UiPanel GetInstance
    {
        get
        {
            if(_instance == null)
            {
                //_instance = new UiPanel();
                _instance = FindObjectOfType(typeof(UiPanel)) as UiPanel;
                if (_instance == null)
                    Debug.LogError("UiPanel No Active!!!");
            }
            return _instance;
        }
    }

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
        if(Input.GetKeyDown(KeyCode.C))
        {
            m_CheckInfoActive = !m_CheckInfoActive;
            ListUi[2].SetActive(m_CheckInfoActive);
        }

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
}
