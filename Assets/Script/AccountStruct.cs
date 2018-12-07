using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

[Serializable]
public class AccountItemInfo
{
    public string Name;
    public int Type;
    public int Value;
    public int Cost;

    public AccountItemInfo(string name, int type, int value, int cost)
    {
        Name = name;
        Type = type;
        Value = value;
        Cost = cost;
        Debug.Log("Account_'"+name+"'Info init");
    }
}

[Serializable]
public class AccountPlayerInfo
{
    public int Level;
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Exp;
    public string Id;
    public string Name;

    public int PlayerGold;

    public AccountPlayerInfo(int lv, int hp, int mp, int atk, int def, string name, string id)
    {
        Level = lv;
        Hp = hp;
        Mp = mp;
        Atk = atk;
        Def = def;
        Id = id;
        Name = name;
        Exp = 0;
        PlayerGold = 0;
        Debug.Log("Account_'Player'Info init");
    }
}

[Serializable]
public class AccountMonsterInfo
{
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Exp;
    public bool IsBoss;
    public string Name;

    public AccountMonsterInfo(int exp, int hp, int mp, int atk, int def, string name, bool isboss)
    {
        Exp = exp;
        Hp = hp;
        Mp = mp;
        Atk = atk;
        Def = def;
        Name = name;
        IsBoss = isboss;
        Debug.Log("Account_'Monster'Info init");
    }
}