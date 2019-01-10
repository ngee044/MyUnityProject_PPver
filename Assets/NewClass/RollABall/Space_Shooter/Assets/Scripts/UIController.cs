using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

    public Text ScoreText, GameStatusText;
    public Button RestartButton;
    public Image HpBar;
    public Image BossHpBar;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        GameStatusText.text = "";
        RestartButton.onClick.AddListener(GameController.Instance.on_ResetButton_clicked);
        RestartButton.gameObject.SetActive(false);
    }
	
    public void ShowScore(int value)
    {
        ScoreText.text = "Score : " + value.ToString();
        //ScoreText.text = string.Format("Score : {0}", value.ToString());
    }

    public void ShowHpBar(float value)
    {
        HpBar.fillAmount = value;
    }

    public void ShowSatusMessage(string msg)
    {
        GameStatusText.text = msg;
        //if(msg == "")
        //    RestartButton.gameObject.SetActive(false);
        //else
        //    RestartButton.gameObject.SetActive(true);
    }
}
