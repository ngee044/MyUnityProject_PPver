using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController GetInstance;
    public Text moneyText, incomText;
    public GameObject ResultWindow;
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

    public void ShowHp(float value)
    {

    }

    public void ShowMoney(float value)
    {
        MoneyText.text = value.ToString("F1");
    }

    public void ShowResultWindow(float income)
    {
        ResultWindow.SetActive(true);
        StartCoroutine(ShowIncomeResult(income));
    }

    private IEnumerator ShowIncomeResult(float money)
    {
        //점수 및 결과 창 연출 부분의 코드 입니다. 
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate(); // fixedUpdate 0.02 second (dog_honey_tips!!)
        float currentShowMoeny = 0;
        float moneyAddGap = money / 150;

        while(currentShowMoeny < money)
        {
            currentShowMoeny += moneyAddGap;
            incomText.text = currentShowMoeny.ToString("F1");

            yield return fixedUpdate;
        }
        incomText.text = money.ToString("F1");
    }
}
