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
            STATUS playermotion = CharacterMgr.GetInstance.GetPlayer.MontionStatus;
            if (player != null && playermotion >= STATUS.STATUS_NOMAL)
            {
                nav.SetDestination(player.transform.position);
                player = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                Debug.Log("player is null " + player);
                nav.SetDestination(new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f)) * Time.deltaTime);
            }
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
        this.transform.position = new Vector3(Random.Range(- 5.3f,12.12f), 0.03f, Random.Range(-5.9f, 6.9f));
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
            Destroy(rect.transform.gameObject);
        }
        else if(rect.collider.tag == "Player")
        {
            //주인공과 충돌하였을때
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
            //this.gameObject.SetActive(false);

            CharacterMgr.GetInstance.GetPlayer.PlayerExp += m_Monster.EXP;
            CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold += 350;
            Destroy(this.gameObject);
        }
    }



}
