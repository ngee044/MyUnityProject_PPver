using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : MonoBehaviour
{
    private static CharacterMgr _instance = null;

    public static CharacterMgr GetInstance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(CharacterMgr)) as CharacterMgr;
                if (_instance == null)
                    Debug.LogError("CharacterMgr No Active!!!");
            }
            return _instance;
        }
    }

    private List<Monster> _Monster = new List<Monster>();
    private Monster _Boss = null;
    private Player _Player = null;

    public Player GetPlayer
    {
        get { return _Player; }
    }

    public Monster GetBoss
    {
        get { return _Boss; }
    }

    public Monster GetMonster(int i)
    {
        return _Monster[i];
    }

    public void CreateMonster(bool is_Boss,string Name, int hp, int mp, int atk, int def)
    {
        if (is_Boss)
        {
            if (_Boss != null)
            {
                _Boss = new Monster("BossMonster", 1500, 0, 90, 35);
            }
        }
        else
        {
            Monster monster = new Monster(Name, hp, mp, atk, def);
            _Monster.Add(monster);
        }
    }

    public void CreatePlayer(string Name, int nid)
    {
        Debug.Log("CharacterMgr - CreatePlayer()");
        _Player = new Player(nid, name, 150, 100, 30, 10, 1);
    }
}
