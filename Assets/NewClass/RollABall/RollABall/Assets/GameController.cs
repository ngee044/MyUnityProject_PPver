using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int m_CurrentScore;
    private const int PassScore = 10;
    public UIContrller uiCntl;

    // Use this for initialization
    void Start() {
        m_CurrentScore = 0;
    }

    public void AddScore(int amount)
    {
        m_CurrentScore += amount;
        Debug.Log(m_CurrentScore);

        if (m_CurrentScore >= PassScore)
        {
            //Game Clear;
            uiCntl.GameFinish();
        }
        else
        {
            uiCntl.ShowScore(m_CurrentScore);
        }
    }
}
