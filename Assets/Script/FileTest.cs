using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

[Serializable]
public class info
{
    public info(int i)
    {
        id = i;
        str = "ngee044 = " + i;
    }
    public info()
    { }
    public int id;
    public string str;
}

public class FileTest : MonoBehaviour {
    public Dictionary<int, info> m_Dictionary = new Dictionary<int, info>();
    public int id;
    public string str;
   
    void Start()
    {
        CreateFile();
        ReadFile();
    }

    void CreateFile()
    {
        Debug.Log("CreateFile Start");
        Stream file = File.Open(Application.dataPath + "/test.txt", FileMode.OpenOrCreate, FileAccess.Write);
        var bf = new BinaryFormatter();

        for (int i = 0; i < 50; i++)
        {
            m_Dictionary.Add(i, new info(i));
        }

        bf.Serialize(file, m_Dictionary);
        file.Close();
    }

    void ReadFile()
    {
        Debug.Log("ReadFile Start");
        var bf = new BinaryFormatter();
        using (Stream stream = File.Open(Application.dataPath + "/test.txt", FileMode.Open))
        {
            Dictionary<int, info> Tmep_Dictionary = (Dictionary<int, info>)bf.Deserialize(stream);
            stream.Close();

            id = Tmep_Dictionary[5].id;
            str = Tmep_Dictionary[5].str;
            Debug.Log("Deserialize " + id + " " + str);
        }
    }
}
