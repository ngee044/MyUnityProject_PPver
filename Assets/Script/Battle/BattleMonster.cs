using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMonster : MonoBehaviour {
    Monster m_Monster;
    public MonsterType SelectType;
    GameObject labelDmg;
    public Slider MonsterHP;

    static int taget;

    // Use this for initialization
    void Start() {
        Debug.Log("Make "+SelectType + " num = "+ (int)SelectType);
        taget = (int)SelectType;
        Monster monster = CharacterMgr.GetInstance.GetMonster[(int)SelectType];
        m_Monster = monster;

    }

    private void OnCollisionEnter(Collision rect)
    {
        int dmg = 1;
        if(rect.collider.tag == "Bullet")
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

    private void OnCollisionStay(Collision rect)
    {

    }

    private void OnCollisionExit(Collision rect)
    {
        //Player 쫒아가는 AI
    }

    IEnumerator SkillEffect(Collision rect)
    {
        yield return new WaitForSeconds(2.0f);
        {
            Destroy(rect.transform.gameObject);
            MonsterHP.gameObject.SetActive(false);
        }
    }

    void DmgLabel(int dmg)
    {

    }

    void CheckMonsterDown()
    {
        if (m_Monster.HP <= 0)
        {
            m_Monster = CharacterMgr.GetInstance.GetMonster[(int)SelectType];
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
