using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMgr : MonoBehaviour
{
    
    List<Character> _Monster = new List<Character>();
    Character _Boss;
    Character _Player;

	public void CreateChartactor(string Name, int nid)
	{

    }

    public void CreateMonster(bool is_Boss,string Name, int hp, int mp, int atk, int def)
    {
        if (is_Boss)
        {
            Monster monster = new Monster("BossMonster", 1500, 0, 90, 35);
            _Boss = monster;
        }
        else
        {
            Monster monster = new Monster(Name, hp, mp, atk, def);
            _Monster.Add(monster);
        }
    }

    public void CreatePlayer(string Name, int nid)
    {
        Player player = new Player(nid,"Unity_Chan",150,100,30,10,1);

        _Player = player;
    }
}
