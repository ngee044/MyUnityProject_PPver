using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int nCount = 0;
    string str = "Now Loading";

    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    string nextSceneName;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;

                }
            }

            yield return new WaitForSeconds(0.5f);

            _text.text += ".";
            if (nCount > 6)
            {
                _text.text = str;
                nCount = 0;
            }
            nCount++;
        }
    }
}