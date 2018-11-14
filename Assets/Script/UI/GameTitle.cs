using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameTitle : MonoBehaviour {

    public Button StartButton;
    public Button ExitButton;
    public List<Sprite> buttonSp = new List<Sprite>();
    public AudioSource titleBGM;
    public AudioSource clickeSound;
    public InputField ConnectCode_LineEdit;
    
    int m_nCount = 0;

    void Awake()
    {
        titleBGM.Play();
    }

	void Start () {
        StartCoroutine(KeyClickEvent());
    }
	
    public void SpriteEevent()
    {
        StartButton.image.sprite = buttonSp[m_nCount];
        ExitButton.image.sprite = buttonSp[m_nCount];
        m_nCount++;

        if (m_nCount == buttonSp.Count) m_nCount = 0;
    }

    IEnumerator KeyClickEvent()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.75f); //1초후 실행
            SpriteEevent();
        }

    }

    public void on_StartButton_clicked()
    {
        if((ConnectCode_LineEdit.text == "ngee044") == false)
        {
            string title = "접속 오류";
            string msg = "올바른 접속 코드를 입력하세요.";
            MessageBox.Show(title, msg, null);
            return;
        }
        clickeSound.Play();
        titleBGM.Stop();
        EditorSceneManager.LoadScene("MainGame");

    }

    public void on_ExitButton_clicked()
    {
        Debug.Log("Into Exit Button");
        clickeSound.Play();
        return;

        titleBGM.Stop();
    }

    // Update is called once per frame
    void Update () {

    }
}
