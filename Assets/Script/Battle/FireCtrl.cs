using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {

    public List<GameObject> Myskill;
    public Transform firePos;
    int type;

    private void Start()
    {
        type = CharacterMgr.GetInstance.GetPlayer.SelectSkill;
    }

    public void Fire()
    {
        Debug.Log("Fire() -- clicked");
        type = CharacterMgr.GetInstance.GetPlayer.SelectSkill;

        if (type == (int)SkilleType.NML_SK)
        {
            CreateBullet();
        }
        else if (type == (int)SkilleType.FRT_SK)
        {
            CreateFrameSkill();
        }
        else if (type == (int)SkilleType.SEC_SK)
        {
            CreateAllFrameSkill();
        }
        else if (type == (int)SkilleType.TID_Skill)
        {
            CreateRecoverySkill();
        }
    }

    void CreateSkill()
    {
        type = CharacterMgr.GetInstance.GetPlayer.SelectSkill;
        Instantiate(Myskill[type], firePos.position + new Vector3 (0,0,0.15f), firePos.rotation);
    }

    void CreateBullet()
    {
        Instantiate(Myskill[type], firePos.position, firePos.rotation);
    }

    void CreateFrameSkill()
    {
        int mpmax = CharacterMgr.GetInstance.GetPlayer.MPMAX;
        int current_mp = CharacterMgr.GetInstance.GetPlayer.MP;

        current_mp -= 15;
        if (current_mp >= 0)
        {
            CharacterMgr.GetInstance.GetPlayer.MP = current_mp;
            CreateSkill();
        }
        else
        {
            MessageBox.Show("마나부족", "마나부족 최소 15이상 되어야 해당 스킬 사용 가능", null);
            return;
        }
    }

    void CreateAllFrameSkill()
    {
        int mpmax = CharacterMgr.GetInstance.GetPlayer.MPMAX;
        int current_mp = CharacterMgr.GetInstance.GetPlayer.MP;

        current_mp -= 20;
        if (current_mp >= 0)
        {
            CharacterMgr.GetInstance.GetPlayer.MP = current_mp;
            CreateSkill();
        }
        else
        {
            MessageBox.Show("마나부족", "마나부족 최소 20이상 되어야 해당 스킬 사용 가능", null);
            return;
        }
    }

    void CreateRecoverySkill()
    {
        int CurHp = CharacterMgr.GetInstance.GetPlayer.HP;
        int CurMaxHp = CharacterMgr.GetInstance.GetPlayer.HPMAX;
        int mpmax = CharacterMgr.GetInstance.GetPlayer.MPMAX;
        int current_mp = CharacterMgr.GetInstance.GetPlayer.MP;

        current_mp -= 20;
        if (current_mp >= 0)
        {
            CharacterMgr.GetInstance.GetPlayer.MP = current_mp;
            CreateSkill();
        }
        else
        {
            MessageBox.Show("마나부족", "마나부족 최소 20이상 되어야 해당 스킬 사용 가능", null);
            return;
        }

        CurHp += 80;

        if (CurHp > CurMaxHp)
            CurHp = CurMaxHp;

        CharacterMgr.GetInstance.GetPlayer.HP = CurHp;
    }
}
