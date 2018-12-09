using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkilleType
{
    NML_SK,
    FRT_SK,
    SEC_SK,
    TID_Skill,
    FTH_Sk,
    SKILLTYPE_End,
}


public class SkillUI : MonoBehaviour {

    List<Sprite> texList = new List<Sprite>();
    public Image img;
    public Button skillbutton;
    public int skillCount;

    int m_skill_number;

    // Use this for initialization
    void Start () {
        texList = ImageMgr.GetInstance.GetImageSkill();
#if false
        foreach (var list in texList)
        {
            Debug.Log(list);
        }
#endif
        m_skill_number = (int)SkilleType.NML_SK; //value 0
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
        CharacterMgr.GetInstance.GetPlayer.SelectSkill = m_skill_number;
    }

    public void on_PrevButton_clicked()
    {
        RenderSprite(--m_skill_number);
        CharacterMgr.GetInstance.GetPlayer.SelectSkill = m_skill_number;
    }

    public void on_SkillButton_clicked()
    {
        Debug.Log("on_SkillButton_clicked() SK value = " + m_skill_number);
    }
}
