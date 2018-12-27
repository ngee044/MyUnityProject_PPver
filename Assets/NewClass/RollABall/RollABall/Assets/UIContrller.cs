using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContrller : MonoBehaviour {

    public Text ScoreText;
    
    public void ShowScore(int score)
    {
        //ScoreText.text = string.Format("SCORE : {0}",score.ToString());
        ScoreText.text = "SCORE : " + score.ToString();
    }

    public void GameFinish()
    {
        ScoreText.text = "Game Clear!!";
    }
}
