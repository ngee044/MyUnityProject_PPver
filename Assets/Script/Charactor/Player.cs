﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfomation
{
    public ItemInfomation()
    {
        HP_Potion = 0;
        MP_Potion = 0;
        ATK_Potion = 0;
        DEF_Potion = 0;
        EXP_Potion = 0;
        NODMG_Potion = 0;
        Gold = 500;
    }

    public int Gold;
    public int HP_Potion;
    public int MP_Potion;
    public int ATK_Potion;
    public int DEF_Potion;
    public int EXP_Potion;
    public int NODMG_Potion;
}

public class Player : Character
{
    int _Lv;
    string _ID;
    int _Exp;
    int _ExpMax;
    public ItemInfomation PlayerItem;
    public int SelectSkill { get; set; }

    public int GetPlayerInfo(CharacterInfo type)
    {
        return 0;
    }

    public Player(string id, string Name, int hp, int mp, int atk, int def, int StartLv)
    {
        Debug.Log("플레이어 클래스 진입");
        PlayerID = id;
        PlayerLevel = StartLv;
        PlayerExp = 0;
        PlayerExpMax = 100 * _Lv;

        NAME = Name;
        HP = HPMAX = hp;
        MP = MPMAX = mp;
        ATK = atk;
        DEF = def;

        PlayerItem = new ItemInfomation();
        SelectSkill = (int)SkilleType.NML_SK;
    }
    ~Player()
    {

    }
    public void PlayerLevelUp()
    {
        if (PlayerExp >= PlayerExpMax)
        {
            PlayerExp = PlayerExp - PlayerExpMax;
            PlayerLevel++;
            PlayerExpMax = 100 * PlayerLevel;

            int GetNum = Random.Range(5, 16);
            HPMAX += GetNum;
            MPMAX += GetNum;
            HP = HPMAX;
            MP = MPMAX;
            ATK += GetNum;
            DEF += GetNum;
            PlayerLevelUp();
        }
    }
    public int PlayerExpMax
    {
        set { _ExpMax = value; }
        get { return _ExpMax; }
    }
    public int PlayerLevel
    {
        set { _Lv = value; }
        get { return _Lv;  }
    }
    public string PlayerID
    {
        set { _ID = value; }
        get { return _ID;  }
    }
    public int PlayerExp
    {
        set { _Exp = value; }
        get { return _Exp;  }
    }
}
