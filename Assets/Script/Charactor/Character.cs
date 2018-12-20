using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATUS
{
    STATUS_DOWN = -1,
    STATUS_NOMAL = 0,
    STATUS_ATK,
    STATUS_RUN,
    STATUS_END,
}

public struct Status
{
    public string Name;
    public int hpMax;
    public int mpMax;
    public int hp;
    public int mp;
    public int atk;
    public int def;
}

public partial class Character : MonoBehaviour
{
    protected Status status;
    public STATUS motion = STATUS.STATUS_NOMAL;

    public STATUS MontionStatus
    {
        set { motion = value; }
        get { return motion; }
    }

    public string NAME
    {
        set { status.Name = value; }
        get { return status.Name; }
    }
    public int HP
    {
        set { status.hp = value; }
        get { return status.hp; }
    }
    public int MP
    {
        set { status.mp = value; }
        get { return status.mp; }
    }
    public int HPMAX
    {
        set { status.hpMax = value; }
        get { return status.hpMax; }
    }
    public int MPMAX
    {
        set { status.mpMax = value; }
        get { return status.mpMax; }
    }
    public int ATK
    {
        set { status.atk = value; }
        get { return status.atk; }
    }
    public int DEF
    {
        set { status.def = value; }
        get { return status.def; }
    }
}
