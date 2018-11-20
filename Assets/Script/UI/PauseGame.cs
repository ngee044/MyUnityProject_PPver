using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseGame : MonoBehaviour {

    bool m_IsPause;

    // Use this for initialization
    void Start () {
        m_IsPause = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
            m_IsPause = !m_IsPause;

        if (!m_IsPause)
            Time.timeScale = 1f;
        else
            Time.timeScale = 1f;
    }

    public void on_Restart_button_clicked()
    {
        string title = "게임 재시작";
        string text = "정말 게임을 다시 시작 하시겠습니까?";

        MessageBox.Show(title, text, 
            new MsgOptions
            {
                cancelButtonTitle = "NO",
                CancelButtonDelegate = () =>
                {
                    Debug.Log("NO");
                },
                okButtonTitle = "Yes",
                OkButtonDelegate = () =>
                {
                    Debug.Log("Yes");
                }
            });
    }

    public void on_MainMenu_button_clicked()
    {
        string title = "메인 메뉴 돌아가기";
        string text = "정말 메뉴로 돌아가시겠습니까?";

        MessageBox.Show(title, text, 
            new MsgOptions
            {
                cancelButtonTitle = "NO",
                CancelButtonDelegate = () =>
                {
                    Debug.Log("NO");
                },
                okButtonTitle = "Yes",
                OkButtonDelegate = () =>
                {
                    LoadingUi.LoadScene("GameTitle");
                    //EditorSceneManager.LoadScene("GameTitle");
                }
            });
    }

    public void on_rejected_clicked()
    {
        m_IsPause = !m_IsPause;
    }
}
