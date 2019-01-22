using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class stat
{
    public int iconId;
    public string name;
    public string contents; //fomat string
    public int currentLv;

    public float costBase;
    public float costWeight;
    public double costCurrent;

    public float valueBase;
    public float valueWeight;
    public double valueCurrent;
}

public class PlayerStatusController : MonoBehaviour
{
    [SerializeField]
    private stat[] infos;
    [SerializeField]
    private Sprite[] icons;
    [SerializeField]
    private ListElement[] elements;


    private void Awake()
    {
        infos = new stat[2];

        infos[0] = new stat();
        infos[0].iconId = 0;
        infos[0].name = "물약";
        infos[0].contents = "HP <color=red>10</color> 회복";
        infos[0].currentLv = 0;

        infos[0].costBase = 100;
        infos[0].costCurrent = 1.07f;
        infos[0].costWeight = infos[0].costBase * Mathf.Pow(infos[0].costWeight, infos[0].currentLv);

        infos[0].valueBase = 10;
        infos[0].valueWeight = 1.04f;
        infos[0].valueCurrent = infos[0].costBase * Mathf.Pow(infos[0].valueWeight, infos[0].currentLv);

        for(int i = 0; i < elements.Length; i++)
        {
            elements[i].Init(icons[infos[i].iconId], 
                             infos[i].name, 
                             infos[i].costCurrent.ToString("f1"),
                             string.Format(infos[i].contents, infos[i].valueCurrent.ToString("f1")),"구매");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
