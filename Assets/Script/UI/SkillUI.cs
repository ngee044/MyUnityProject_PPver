using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    List<Sprite> texList = new List<Sprite>();
    public Image img;
    public Button skillbutton;
    public int skillCount;

    int m_skill_number;

    // Use this for initialization
    void Start () {
        texList = ImageMgr.GetInstance.GetImageSkill();
        foreach (var list in texList)
        {
            Debug.Log(list);
        }
        m_skill_number = 0;
        RenderSprite(m_skill_number);
    }

    void RenderSprite(int n)
    {
        int nCount;
        nCount = n; // texList.Count;

        if (nCount + 1 > skillCount)
            m_skill_number = 0;
        else if (nCount < 0)
            m_skill_number = skillCount - 1;
        else if (nCount == 0)
            m_skill_number = 0;

        img.sprite = texList[m_skill_number];
    }

    public void on_NextButton_clicked()
    {
        RenderSprite(++m_skill_number);
    }

    public void on_PrevButton_clicked()
    {
        RenderSprite(--m_skill_number);
    }

    public void on_SkillButton_clicked()
    {
        Debug.Log("on Skill Button");
        int mpmax = CharacterMgr.GetInstance.GetPlayer.MPMAX;
        int current_mp = CharacterMgr.GetInstance.GetPlayer.MP;

        if(m_skill_number == 0 || m_skill_number == 2)
        {
            current_mp -= 20;
            if(current_mp >= 0)
            {
                CharacterMgr.GetInstance.GetPlayer.MP = current_mp;
            }
            else
            {
                MessageBox.Show("마나부족", "마나부족 최소 20이상 되어야 해당 스킬 사용 가능", null);
            }
        }
        else if(m_skill_number == 1)
        {
            current_mp -= 15;
            if (current_mp >= 0)
            {
                CharacterMgr.GetInstance.GetPlayer.MP = current_mp;
            }
            else
            {
                MessageBox.Show("마나부족", "마나부족 최소 15이상 되어야 해당 스킬 사용 가능", null);
            }
        }
    }
}
