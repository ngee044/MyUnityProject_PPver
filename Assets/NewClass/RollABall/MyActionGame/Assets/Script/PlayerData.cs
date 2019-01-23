using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float value1;
    [SerializeField]
    private float value2;
    [SerializeField]
    private float value3;

    public static PlayerData GetInstance;
    private void Awake()
    {
        if(GetInstance == null)
        {
            GetInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddValue1(float value)
    {
        value1 += value;
    }
    public void AddValue2(float value)
    {
        value2 += value;
    }
    public void AddValue3(float value)
    {
        value3 += value;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
