using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : Character
{
    public Monster(string Name, int hp, int mp, int atk, int def)
    {
        status.Name = name;
        status.hp = status.hpMax = hp;
        status.mp = status.mpMax = mp;
        status.atk = atk;
        status.def = def;
    }
}
