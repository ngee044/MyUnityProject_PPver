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

    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    public List<Monster> GetMonster
    {
        get { return _Monster; } 
    }

    public void CreateMonster(MonsterType index)
    {
        Debug.Log("CharacterMgr - CreateMonster() MonsterType =" + index);
        bool is_Boss = AccountMgr.GetInstance.GetMonsterInfo[(int)index].IsBoss;

        string name = AccountMgr.GetInstance.GetMonsterInfo[(int)index].Name;
        int hp = AccountMgr.GetInstance.GetMonsterInfo[(int)index].Hp;
        int mp = AccountMgr.GetInstance.GetMonsterInfo[(int)index].Mp;
        int atk = AccountMgr.GetInstance.GetMonsterInfo[(int)index].Atk;
        int def = AccountMgr.GetInstance.GetMonsterInfo[(int)index].Def;

        if (is_Boss)
        {
            if(_Boss == null)
                _Boss = new Monster(name, hp, mp, atk, def);
        }
        else
        {
            Monster monster = new Monster(name, hp, mp, atk, def);
            _Monster.Add(monster);
        }
    }

    public void CreatePlayer(string Name, string id)
    {
        Debug.Log("CharacterMgr - CreatePlayer()");

        int index = AccountMgr.GetInstance.PlayerIndex;

        int hp = AccountMgr.GetInstance.GetPlayerInfo[index].Hp;
        int mp = AccountMgr.GetInstance.GetPlayerInfo[index].Mp;
        int atk = AccountMgr.GetInstance.GetPlayerInfo[index].Atk;
        int def = AccountMgr.GetInstance.GetPlayerInfo[index].Def;
        int lv = AccountMgr.GetInstance.GetPlayerInfo[index].Level;

#if false
        _Player = new Player(id, Name, 150, 100, 30, 10, 1);
#else
        _Player = new Player(id, Name, hp, mp, atk, def, lv);
#endif
    }
}
