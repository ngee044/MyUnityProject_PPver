using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class info
{
    public int id;
    public string str;
}

public class FileTest : MonoBehaviour {



    public Dictionary<int, info> m_Dictionary = new Dictionary<int, info>();

    private info myInfo;
    private info tempInfo;
    void SetInfo(int num, string name)
    {
        myInfo = new info();
        myInfo.id = num;
        myInfo.str = name;
    }
    
    void Start()
    {
        SetInfo(0, "one");
        m_Dictionary.Add(0, myInfo);
        Debug.Log("rrrrrrrrrrrrrrrr");
        CreateFile();
        Debug.Log("cccccccccccccccc");
        ReadFile();

        Debug.Log("aaaaaaaaaaaaa");

    }

    void CreateFile()
    {
#if false
        var b = new BinaryFormatter();
        Stream stream = File.Open("c:\\test.txt", FileMode.OpenOrCreate, FileAccess.Write);
        b.Serialize(stream, (object)m_Dictionary);
        stream.Close();
#else
        Debug.Log("111111111");
        var b = new BinaryFormatter();
        Debug.Log("111111111");
        Stream stream = new FileStream("c:\\test.txt", FileMode.Create, FileAccess.Write, FileShare.None);
        Debug.Log("111111111");
  
        b.Serialize(stream, (object)m_Dictionary);
        Debug.Log("111111111");
        stream.Close();

        Debug.Log("Serialization Complete!");
        
#endif
    }

    void ReadFile()
    {
        var r = new BinaryFormatter();
        Stream streambuffer = new FileStream("c:\\test.txt", FileMode.Open, FileAccess.Read);

        info info = (info)r.Deserialize(streambuffer);

        int n = info.id;
        string str = info.str;

        Debug.Log("Deserialize " + n + " " + str);
    }

}
