using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Player Struct


    struct Plyaer_stats
    {
        Status p;
        public int Lv;

        public int nID;
        public Plyaer_stats(int id, string Name, int hp, int mp, int atk, int def, int StartLv)
        {
            nID = id;
            Lv = StartLv;
            p.Name = Name;

            p.hp = hp;
            p.mp = mp;
            p.atk = atk;
            p.def = def;
        }
    }
    #endregion

    public Player(int id, string Name, int hp, int mp, int atk, int def, int StartLv)
    {
        Plyaer_stats player = new Plyaer_stats(id, Name, hp, mp, atk, def, StartLv);
    }

}
