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

    public void CreateMonster(MonsterType index)
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Monster");

        var i = (int)index;
        string name = (string)data[i]["NAME"];
        int hp = (int)data[i]["HP"];
        int mp = (int)data[i]["MP"];
        int atk = (int)data[i]["ATK"];
        int def = (int)data[i]["DEF"];
        bool is_Boss = (bool)data[i]["BOSS"];
        
        if (is_Boss)
        {
            if (_Boss != null)
            {
                _Boss = new Monster("BossMonster", 1500, 0, 90, 35);
            }
        }
        else
        {
            Monster monster = new Monster(name, hp, mp, atk, def);
            _Monster.Add(monster);
        }
    }

    public void CreatePlayer(string Name, int nid)
    {
        Debug.Log("CharacterMgr - CreatePlayer()");
#if false
        List<Dictionary<string, object>> Table = CSVReader.Read("MyPlayerInfo");

        Debug.Log("Data Create()?? " + Table.Count);
        string name = (string)Table[0]["NAME"];

        int lv = (int)Table[0]["LV"];
        int hp = (int)Table[0]["HP"];
        int mp = (int)Table[0]["MP"];
        int atk = (int)Table[0]["ATK"];
        int def = (int)Table[0]["DEF"];
        Debug.Log("info " + lv + " " + hp + " " + mp + " " + atk + " " +def + " ");
#endif
        _Player = new Player(nid, Name, 150, 100, 30, 10, 1);
        //_Player = new Player(nid, name, hp, mp, atk, def, lv);
    }
}
