using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

[Serializable]
public class AccountPlayerInfo
{
    public AccountPlayerInfo(int lv, int hp, int mp, int atk, int def, string name, string id)
    {
        lv = Level;
        hp = Hp;
        mp = Mp;
        atk = Atk;
        def = Def;
        id = Id;
        name = Name;
    }

    public int Level;
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public string Id;
    public string Name;
}

public class AccountMgr : MonoBehaviour {

    private static AccountMgr _instance = null;

    public static AccountMgr GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(AccountMgr)) as AccountMgr;
                if (_instance == null)
                    Debug.LogError("CharacterMgr No Active!!!");
            }
            return _instance;
        }
    }



    Dictionary<int, AccountPlayerInfo> m_AccountDictionary = new Dictionary<int, AccountPlayerInfo>();
    Dictionary<int, AccountPlayerInfo> TempDictionary = new Dictionary<int, AccountPlayerInfo>();

    List<Dictionary<string, object>> m_PlayerTable = CSVReader.Read("MyPlayerInfo");
    List<Dictionary<string, object>> m_MonsterTable = CSVReader.Read("Monster");
    private AccountPlayerInfo m_playerInfo;

    public AccountPlayerInfo GetPlayerInfo
    {
        get { return m_playerInfo; }
    }
    
    void Awake()
    {
        SetTableData();
        CreateBinaryFile();
        ReadBinaryFile();
    }

    void Start()
    {
    }
    
    public void SetTableData()
    {
        Debug.Log("Data Create()?? " + m_PlayerTable.Count);

        int Level;
        int Hp;
        int Mp;
        int Atk;
        int Def;
        string Id;
        string Name;

        Name = (string)m_PlayerTable[0]["NAME"].ToString();
        Level = (int)m_PlayerTable[0]["LV"];
        Hp = (int)m_PlayerTable[0]["HP"];
        Mp = (int)m_PlayerTable[0]["MP"];
        Atk = (int)m_PlayerTable[0]["ATK"];
        Def = (int)m_PlayerTable[0]["DEF"];
        Id = "ngee044";

        m_playerInfo = new AccountPlayerInfo(Level, Hp, Mp, Atk, Def, Name, Id);
        Debug.Log("info " + Level + " " + Hp + " " + Mp + " " + Atk + " " + Def + " ");
    }

    public void CreateBinaryFile()
    {
        Stream file = File.Open(Application.dataPath + "/PlayerInfoAccount.bin", FileMode.OpenOrCreate, FileAccess.Write);
        var bf = new BinaryFormatter();

        m_AccountDictionary.Add(0, m_playerInfo);

        bf.Serialize(file, m_AccountDictionary);
        file.Close();
    }

    public void ReadBinaryFile()
    {
        var bf = new BinaryFormatter();
        using (Stream stream = File.Open(Application.dataPath + "/PlayerInfoAccount.bin", FileMode.Open))
        {
            //TempDictionary = (Dictionary<int, AccountPlayerInfo>)bf.Deserialize(stream);
            m_AccountDictionary = (Dictionary<int, AccountPlayerInfo>)bf.Deserialize(stream);
            stream.Close();

            Debug.Log(m_AccountDictionary[0].Name);
            Debug.Log(m_AccountDictionary[0].Hp);
            Debug.Log(m_AccountDictionary[0].Atk);
            Debug.Log(m_AccountDictionary[0].Def);
        }
    }

    
}
