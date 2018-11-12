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
    int m_nCount = 0;

    void Awake()
    {

    }

	void Start () {
        titleBGM.Play();
        StartCoroutine(KeyClickEvent());
    }
	
    public void SpriteEevent()
    {
        
    }

    IEnumerator KeyClickEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); //1초후 실행
            Debug.Log(buttonSp.Count);
            Debug.Log("cnt = " + m_nCount);
            StartButton.image.sprite = buttonSp[m_nCount];
            ExitButton.image.sprite = buttonSp[m_nCount];
            m_nCount++;

            if (m_nCount == buttonSp.Count) m_nCount = 0;
        }
    }

    public void on_StartButton_clicked()
    {
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
