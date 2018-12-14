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
    public DungeonUI DungeonUi;
    List<GameObject> m_monster;
    int MonsterCount;

    DungeonLevel m_Level = DungeonLevel.Dungeon_1;

    int Difficulty_Lv
    {
        set { m_Level = (DungeonLevel)value; }
        get { return (int)m_Level; }
    }

    // Use this for initialization
    void Start () {
        if (DungeonUi != null)
        {
            DungeonUi.Init();
        }
        else
        {
            Debug.Log("DungeonUi is Null");
        }


    }
	
	// Update is called once per frame
	void Update () {
		if(DungeonUi.exec == false)
        {
            Difficulty_Lv = DungeonUi.GetDungeonLv;
            MonsterCount = DungeonUi.GetMonsterCount;
            
        }
	}
}
