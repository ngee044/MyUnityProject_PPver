using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class VersionChecker
{
    private const int VERSION_NUMBER = 28;

    private string VersionURL = "https://www."; //url ����
    private Dictionary<string, strnig> DataPair;

    void Start()
    {
        DataPair = new Dictionary<string, strnig>();
        StartCoroutine(GetVersion());
    }

    private IEnumerator GetVersion()
    {
        WWW www = new WWW(VersionURL);
        yield return www;
        string data = "{" + System.Text.Encoder.UTF8.GetsString(www.bytes, 3, www.bytes.Length - 3);
        //data�� �Ľ��ϴ°� ���� ������� ���� �ڵ�� json �Ľ��̸� ���� ���鼭 data �Ľ��� ����� �� �� �ִ��� Ȯ���ؾ��Ѵ�.
        DataPair = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        if (VERSION_NUMBER <= int.Parse(DataPair["version"]))
        {
            Debug.log("need New version");
        }
        else
        {
            Debug.log("Right version check!! go to next stair");
        }
    }
}
