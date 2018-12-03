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
    public Text LineEdit_Text;

    int m_nCount = 0;

    void Awake()
    {
        titleBGM.Play();
    }

    void Start() {
        
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

    public void InitData()
    {
        int index = AccountMgr.GetInstance.PlayerIndex;
        CharacterMgr.GetInstance.CreatePlayer(AccountMgr.GetInstance.GetPlayerInfo[index].Name, AccountMgr.GetInstance.GetPlayerInfo[index].Id);
        Debug.Log("플레이어 캐릭터 생성 완료");
        Debug.Log("Account Update 실행");
        AccountMgr.GetInstance.StartUpdate = true;
    }

    public void on_StartButton_clicked()
    {
        bool isCheck = false;

        for (int i = 0; i < AccountMgr.GetInstance.GetPlayerInfo.Count; i++)
        {
            // ID search
            if ((ConnectCode_LineEdit.text == AccountMgr.GetInstance.GetPlayerInfo[i].Id) == true)
            {
                isCheck = true;
                AccountMgr.GetInstance.PlayerIndex = i;
                break;
            }
        }

        if(!isCheck)
        {
            string title = "접속 오류";
            string msg = "올바른 접속 코드를 입력하세요.";
            MessageBox.Show(title, msg, null);
            return;
        }

        InitData();
        clickeSound.Play();
        titleBGM.Stop();
        LoadingUi.LoadScene("MainGame");
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
