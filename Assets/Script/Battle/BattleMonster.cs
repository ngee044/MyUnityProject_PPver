using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BattleMonster : MonoBehaviour {
    Monster m_Monster;
    GameObject labelDmg;

    public MonsterType SelectType;
    public Slider MonsterHP;
    public GameObject Target;
    private GameObject player;
    public NavMeshAgent nav;
    private NavMeshAgent m_nav;
    bool isFirst;
    int taget;

    private void Start()
    {
        isFirst = true;
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirst == false)
        {
            if (player != null)
                nav.SetDestination(player.transform.position);
            else
                Debug.Log("player is null " + player);
        }
    }

    public void init() {
        Debug.Log("Make "+SelectType + " num = "+ (int)SelectType);
        taget = (int)SelectType;
        Monster monster = CharacterMgr.GetInstance.GetMonster[(int)SelectType];
        m_Monster = new Monster(monster.NAME,
                                monster.HP,
                                monster.MP,
                                monster.ATK,
                                monster.DEF,
                                monster.EXP);

        player = GameObject.FindGameObjectWithTag("Player");
        //m_nav = GetComponent<NavMeshAgent>();
        //m_nav.speed = 1.5f;
        isFirst = false;
    }

    private void OnCollisionEnter(Collision rect)
    {
        int dmg = 1;

        if (rect.collider.tag == "Bullet")
        {
            int GetNum = Random.Range(1, 30);
            dmg = CharacterMgr.GetInstance.GetPlayer.ATK + GetNum;
            Destroy(rect.transform.gameObject);

        }
        else if(rect.collider.tag == "skill")
        {
            dmg = CharacterMgr.GetInstance.GetPlayer.ATK + On_skilldamge();
        }

        MonsterHP.gameObject.SetActive(true);
        m_Monster.HP -= dmg;
        MonsterHP.value = m_Monster.HP / m_Monster.HPMAX;
        CheckMonsterDown();
        StartCoroutine(SkillEffect(rect));
        Debug.Log("DMG = " + dmg + "Monster HP : " + m_Monster.HP);

    }

    private void OnCollisionStay(Collision rect)
    {

    }

    private void OnCollisionExit(Collision rect)
    {
        //Player 쫒아가는 AI
    }

    int On_skilldamge()
    {
        int dmg = 0;
        int type = CharacterMgr.GetInstance.GetPlayer.SelectSkill;

        if (type == (int)SkilleType.FRT_SK)
            dmg = 100;
        else if (type == (int)SkilleType.SEC_SK)
            dmg = 120;
        else if (type == (int)SkilleType.TID_Skill)
            dmg = 500;
        else
            dmg = CharacterMgr.GetInstance.GetPlayer.ATK;

        return dmg;
    }
    IEnumerator SkillEffect(Collision rect)
    {
        yield return new WaitForSeconds(2.0f);
        {
            Destroy(rect.transform.gameObject);
            MonsterHP.gameObject.SetActive(false);
        }
    }
    void CheckMonsterDown()
    {
        if (m_Monster.HP <= 0)
        {
            m_Monster = CharacterMgr.GetInstance.GetMonster[(int)SelectType];
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);

            CharacterMgr.GetInstance.GetPlayer.PlayerExp += m_Monster.EXP;
        }
    }



}
