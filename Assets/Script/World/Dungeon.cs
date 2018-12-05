using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DungeonLevel
{
    Dungeon_1,
    Dungeon_2,
    Dungeon_3,
}

public class Dungeon : MonoBehaviour {

    GameObject m_PrefabMonster;
    DungeonLevel m_Level = DungeonLevel.Dungeon_1;

    DungeonLevel Difficulty_Lv
    {
        set { m_Level = value; }
        get { return m_Level; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
