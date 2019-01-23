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

    private float discoutRate;

    private void Awake()
    {
        infos = new stat[2];
        discoutRate = 0;

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
                             string.Format(infos[i].contents, infos[i].valueCurrent.ToString("f1")),
                             "구매",
                             i,
                             LevelUP);
        }
    }

    public void ChangeDelegate()
    {
        elements[1].ChangeCallBack((int a) => { Debug.Log(a + "haha"); });
    }

    public void AddDiscout(float value)
    {
        discoutRate += value;
        for(int i = 0; i < infos.Length; i++)
        {
            CalcInfo(i);
            elements[i].Renew(infos[i].costCurrent.ToString("f1"),
                string.Format(infos[i].contents, infos[i].valueCurrent.ToString("F1")), "구매");
        }
    }

    public void CalcInfo(int id)
    {
        infos[id].costCurrent = infos[id].costBase * Math.Pow(infos[id].costWeight, infos[id].currentLv) * (1 - discoutRate);
        infos[id].valueCurrent = infos[id].valueBase * Math.Pow(infos[id].valueWeight, infos[id].currentLv);
    }

    public void LevelUP(int id)
    {
        int maxlv = 5;

        CalcInfo(id);
        if(infos[id].currentLv < maxlv) // 5 is maxlv
        {
            infos[id].currentLv++;
            CalcInfo(id);
            PlayerData.GetInstance.AddValue1(5);
            string purchaseStr = "";
            if(infos[id].currentLv < maxlv)
            {
                purchaseStr = "구매";
            }
            else
            {
                purchaseStr = "완료";
            }
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
