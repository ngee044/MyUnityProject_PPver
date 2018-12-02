using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public enum Map_eType
{
    eTYPE_MAPSTART,
    eTYPE_Title,
    eTYPE_Dungeon,
    eTYPE_Village,
    eTYPE_END,
}

public class LoadingUi : MonoBehaviour
{
    public static string nextScene;
    public Text _text;
    public Slider bar;
    int nCount = 0;
    string str = "Now Loading";
    
    private void Start()
    {
        bar.value = 0.0f;
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        Debug.Log("Load Scene : " + sceneName);
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while(true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            _text.text += ".";
            if (nCount > 6)
            {
                _text.text = str;
                nCount = 0;
            }
            nCount++;

            yield return null;
            Debug.Log("in "+ op.progress);
            bar.value = op.progress;

            if (bar.value >= 0.9f)
            {
                 Debug.Log("value " + bar.value);
                 Thread.Sleep(150);
                 op.allowSceneActivation = true;
                 yield return true;
            }
        }
    }
}