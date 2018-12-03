using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseGame : MonoBehaviour {

    public GameObject pauseMenu;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

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
                    AccountMgr.GetInstance.Delete();
                    LoadingUi.LoadScene("GameTitle");
                    //EditorSceneManager.LoadScene("GameTitle");
                }
            });
    }

    public void on_rejected_clicked()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
