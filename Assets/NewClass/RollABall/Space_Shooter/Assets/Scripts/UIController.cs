using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

    public Text ScoreText, GameStatusText;


	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        GameStatusText.text = "";

    }
	
    public void ShowScore(int value)
    {
        ScoreText.text = "Score : " + value.ToString();
        //ScoreText.text = string.Format("Score : {0}", value.ToString());
    }

    public void ShowSatusMessage(string msg)
    {
        GameStatusText.text = msg;
    }
}
