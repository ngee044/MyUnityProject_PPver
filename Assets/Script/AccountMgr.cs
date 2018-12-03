using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

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
    //sington patten

    Dictionary<int, AccountPlayerInfo> m_AccountDictionary = new Dictionary<int, AccountPlayerInfo>();
    Dictionary<int, AccountPlayerInfo> TempDictionary = new Dictionary<int, AccountPlayerInfo>();

    List<Dictionary<string, object>> m_PlayerTable;
    List<Dictionary<string, object>> m_MonsterTable;
    List<Dictionary<string, object>> m_ItemTable;
    
    private List<AccountPlayerInfo> m_playerInfo = null;
    private List<AccountMonsterInfo> m_ListmonsterInfo = null;
    private List<AccountItemInfo> m_Listiteminfo = null;
    private int MyPlayerIndex;
    private bool m_bAccountUpdate;

    public bool StartUpdate
    {
        set { m_bAccountUpdate = value; }
        get { return m_bAccountUpdate;  }
    }

    public int PlayerIndex
    {
        set { MyPlayerIndex = value; }
        get { return MyPlayerIndex; }
    }

    public List<AccountPlayerInfo> GetPlayerInfo
    {
        get { return m_playerInfo; }
    }

    public List<AccountMonsterInfo> GetMonsterInfo
    {
        get { return m_ListmonsterInfo; }
    }

    public List<AccountItemInfo> GetItemInfo
    {
        get { return m_Listiteminfo; }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (m_binaryMatter == null)
            m_binaryMatter = new BinaryFormatter();
        if(m_playerInfo == null)
            m_playerInfo = new List<AccountPlayerInfo>();
        if(m_ListmonsterInfo == null)
            m_ListmonsterInfo = new List<AccountMonsterInfo>();
        if (m_Listiteminfo == null)
            m_Listiteminfo = new List<AccountItemInfo>();

        PlayerIndex = 0;
        StartUpdate = false;
    }

    void Start()
    {
        SetPlayerData();
        SetMonsterData();
        SetItemData();
        CreateBinaryFile();
        ReadBinaryFile();
    }

    private void Update()
    {
        if (StartUpdate == true)
        {
            getAccountCharacterInfo();
            Send_PlayertoAccount();
        }
    }

    Stream file;
    BinaryFormatter m_binaryMatter;
    public void getAccountCharacterInfo()
    {
        m_AccountDictionary[MyPlayerIndex].Hp = CharacterMgr.GetInstance.GetPlayer.HP;
        m_AccountDictionary[MyPlayerIndex].Mp = CharacterMgr.GetInstance.GetPlayer.MP;
        m_AccountDictionary[MyPlayerIndex].Atk = CharacterMgr.GetInstance.GetPlayer.ATK;
        m_AccountDictionary[MyPlayerIndex].Def = CharacterMgr.GetInstance.GetPlayer.DEF;
        m_AccountDictionary[MyPlayerIndex].Level = CharacterMgr.GetInstance.GetPlayer.PlayerLevel;
        m_AccountDictionary[MyPlayerIndex].Exp = CharacterMgr.GetInstance.GetPlayer.PlayerExp;

        m_AccountDictionary[MyPlayerIndex].PlayerGold = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold;
    }

    public void Send_PlayertoAccount()
    {
        CharacterMgr.GetInstance.GetPlayer.HP = m_AccountDictionary[MyPlayerIndex].Hp;
        CharacterMgr.GetInstance.GetPlayer.MP = m_AccountDictionary[MyPlayerIndex].Mp;
        CharacterMgr.GetInstance.GetPlayer.ATK = m_AccountDictionary[MyPlayerIndex].Atk;
        CharacterMgr.GetInstance.GetPlayer.DEF = m_AccountDictionary[MyPlayerIndex].Def;
        CharacterMgr.GetInstance.GetPlayer.PlayerLevel = m_AccountDictionary[MyPlayerIndex].Level;
        CharacterMgr.GetInstance.GetPlayer.PlayerExp = m_AccountDictionary[MyPlayerIndex].Exp;
        CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold = m_AccountDictionary[MyPlayerIndex].PlayerGold;
        CharacterMgr.GetInstance.GetPlayer.PlayerLevelUp();
    }

    private void SetPlayerData()
    {
        m_PlayerTable = CSVReader.Read("MyPlayerInfo");

        for (int i = 0; i < m_PlayerTable.Count; i++)
        {
            int Level;
            int Hp;
            int Mp;
            int Atk;
            int Def;
            string Id;
            string Name;

            Name = (string)m_PlayerTable[i]["NAME"].ToString();
            Level = (int)m_PlayerTable[i]["LV"];
            Hp = (int)m_PlayerTable[i]["HP"];
            Mp = (int)m_PlayerTable[i]["MP"];
            Atk = (int)m_PlayerTable[i]["ATK"];
            Def = (int)m_PlayerTable[i]["DEF"];
            Id = (string)m_PlayerTable[i]["ID"].ToString();

            m_playerInfo.Add(new AccountPlayerInfo(Level, Hp, Mp, Atk, Def, Name, Id));
        }
    }

    private void SetMonsterData()
    {
        m_MonsterTable = CSVReader.Read("Monster");
        for (int i = 0; i < m_MonsterTable.Count; i++)
        {
            string Name;
            int Hp;
            int Mp;
            int Atk;
            int Def;
            int Exp;
            int Boss;

            bool CheckBoss = false;
            Name = (string)m_MonsterTable[i]["NAME"].ToString();
            Hp = (int)m_MonsterTable[i]["HP"];
            Mp = (int)m_MonsterTable[i]["MP"];
            Atk = (int)m_MonsterTable[i]["ATK"];
            Def = (int)m_MonsterTable[i]["DEF"];
            Exp = (int)m_MonsterTable[i]["EXP"];
            Boss = (int)m_MonsterTable[i]["BOSS"];

            if (Boss == 1)
                CheckBoss = true;
            else
                CheckBoss = false;

            m_ListmonsterInfo.Add(new AccountMonsterInfo(Exp, Hp, Mp, Atk, Def, Name, CheckBoss));
        }

    }

    public void SetItemData()
    {
        m_ItemTable = CSVReader.Read("ItemInfo");

        for (int i = 0; i < m_ItemTable.Count; i++)
        {
            string Name;
            int Type;
            int Value;
            int Cost;

            Name = (string)m_ItemTable[i]["NAME"].ToString();
            Type = (int)m_ItemTable[i]["TYPE"];
            Value = (int)m_ItemTable[i]["VALUE"];
            Cost = (int)m_ItemTable[i]["COST"];

            m_Listiteminfo.Add(new AccountItemInfo(Name, Type, Value, Cost)); 
        }
    }

    public void CreateBinaryFile()
    {
        Stream file = File.Open(Application.dataPath + "/PlayerInfoAccount.bin", FileMode.OpenOrCreate, FileAccess.Write);

        for(int i = 0; i < m_playerInfo.Count; i++)
           m_AccountDictionary.Add(i, m_playerInfo[i]);

        m_binaryMatter.Serialize(file, m_AccountDictionary);
        file.Close();
    }

    public void SaveBinaryFile()
    {
        Stream file = File.Open(Application.dataPath + "/PlayerInfoAccount.bin", FileMode.OpenOrCreate, FileAccess.Write);

        for (int i = 0; i < m_playerInfo.Count; i++)
            m_AccountDictionary[i] = m_playerInfo[i];

        m_binaryMatter.Serialize(file, m_AccountDictionary);
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

            //Debug.Log(m_AccountDictionary[0].Name.ToString());
            //Debug.Log(m_AccountDictionary[0].Hp);
            //Debug.Log(m_AccountDictionary[0].Atk);
            //Debug.Log(m_AccountDictionary[0].Def);
        }
    }

    public void Delete()
    {
        SaveBinaryFile();
        Destroy(CharacterMgr.GetInstance);
        Destroy(UiPanel.GetInstance);
        Destroy(ImageMgr.GetInstance);
        Destroy(this);
        file.Close();
    }



    
}
