using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : Character
{
#region Monster Struct

    struct Monster_stats
    {
        Status m;
        public Monster_stats(string name, int hp, int mp, int atk, int def)
        {
            m.Name = name;
            m.hp = hp;
            m.mp = mp;
            m.atk = atk;
            m.def = def;
        }
    }
#endregion

    public Monster(string Name, int hp, int mp, int atk, int def)
    {
        Monster_stats monster = new Monster_stats(Name, hp, mp, atk, def);
    }
}
