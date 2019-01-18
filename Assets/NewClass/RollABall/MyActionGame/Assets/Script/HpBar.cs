using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public Image Bar;
    public GameObject hpBarObj;

    public Text Income;
    public GameObject incomObj;

    private void OnEnable()
    {
        hpBarObj.SetActive(false);
        incomObj.SetActive(false);
    }

    public void ShowHp(float value)
    {
        hpBarObj.SetActive(true);
        Bar.fillAmount = value;
    }

    public void ShowIncom(float amount)
    {
        incomObj.SetActive(true);
        Income.text = amount.ToString("F1"); //소수점 첫째짜리까지만 표현
    }
}
