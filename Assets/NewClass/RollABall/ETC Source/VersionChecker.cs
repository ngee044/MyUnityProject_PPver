using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class VersionChecker
{
    private const int VERSION_NUMBER = 28;

    private string VersionURL = "https://www."; //url 저장
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
        //data를 파싱하는건 편한 방법으로 현재 코드는 json 파싱이며 값을 찍어보면서 data 파싱을 제대로 할 수 있는지 확인해야한다.
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
