using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    int _Lv;
    int _nID;
    int _Exp;
    int _ExpMax;

    public int GetPlayerInfo(CharacterInfo type)
    {
        return 0;
    }

    public Player(int id, string Name, int hp, int mp, int atk, int def, int StartLv)
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
            ATK += 2;
            DEF ++;
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
    public int PlayerID
    {
        set { _nID = value; }
        get { return _nID;  }
    }
    public int PlayerExp
    {
        set { _Exp = value; }
        get { return _Exp;  }
    }
}
