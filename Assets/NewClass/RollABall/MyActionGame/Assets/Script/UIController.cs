using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController GetInstance;

    public Text MoneyText;

    private void Awake()
    {
        if(GetInstance == null)
        {
            GetInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ShowMoney(float value)
    {
        MoneyText.text = value.ToString("F1");
    }
}
