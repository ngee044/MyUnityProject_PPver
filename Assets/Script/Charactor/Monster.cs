﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : Character
{
    public int EXP { get; set; }

    public Monster(string Name, int hp, int mp, int atk, int def, int exp)
    {
        NAME = Name;
        HP = HPMAX = hp;
        MP = MPMAX = mp;
        ATK = atk;
        DEF = def;
        EXP = exp;
    }

}
