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
    List<BattleMonster> m_monster;
    int MonsterCount;
    bool m_DungeonStart;

    DungeonLevel m_Level = DungeonLevel.Dungeon_1;

    int Difficulty_Lv
    {
        set { m_Level = (DungeonLevel)value; }
        get { return (int)m_Level; }
    }

    private void Awake()
    {
        m_monster = new List<BattleMonster>();
        m_DungeonStart = true;
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

    bool CheckMonster()
    {
        GameObject m = GameObject.Find("monster(Clone)");

        if (m != null)
            return true;
        else
            return false;
    }

	// Update is called once per frame
	void Update () {
        
        if (!CheckMonster() && !m_DungeonStart)
        {
            //game Clear
            DungeonUi.transform.gameObject.SetActive(true);
            DungeonUi.Init();
            DungeonUi.Complet();

            m_monster.Clear();
            m_DungeonStart = true;

        }

        if (CharacterMgr.GetInstance.GetPlayer.HP <= 0)
        {
            //game over
            DungeonUi.transform.gameObject.SetActive(true);
            DungeonUi.Init();
            DungeonUi.Fail();

            m_monster.Clear();
            m_DungeonStart = true;
            CharacterMgr.GetInstance.GetPlayer.HP = 1;
        }
	}

    public void OnDungeonInfo()
    {
        MonsterCount = DungeonUi.GetMonsterCount+1;
        Difficulty_Lv = DungeonUi.GetDungeonLv;

        Debug.Log("Create DungeonLV " + Difficulty_Lv);
        Debug.Log("Create Monster Count " + MonsterCount);

        for (int i = 0; i < MonsterCount; i++)
        {
            m_PrefabMonster = Resources.Load("monster") as GameObject;
            GameObject go = Instantiate(m_PrefabMonster) as GameObject;
            BattleMonster bm = go.GetComponent<BattleMonster>();

            m_monster.Add(bm);
        }

        foreach (var i in m_monster)
        {
            i.init();
        }

        m_DungeonStart = false;
        DungeonUi.transform.gameObject.SetActive(false);
    }
}
