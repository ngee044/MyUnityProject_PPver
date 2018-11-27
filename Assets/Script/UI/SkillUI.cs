using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Texture2D Skill_Texture;
    List<Sprite> texList = new List<Sprite>();
    public Image img;
    public Button skillbutton;
    public int skillCount;
    int m_skill_number;

    // Use this for initialization
    private void Awake()
    {
        texList = ImageMgr.GetInstance.GetImageSkill();
    }
    void Start () {
        
        
        m_skill_number = 0;
        RenderSprite(m_skill_number);
    }

    void RenderSprite(int n)
    {
        int nCount;
        nCount = n; // texList.Count;
        Debug.Log("current value = " + m_skill_number);
        if (nCount + 1 > skillCount)
            m_skill_number = 0;
        else if (nCount < 0)
            m_skill_number = skillCount - 1;
        else if (nCount == 0)
            m_skill_number = 0;
        Debug.Log("current value = " + m_skill_number);
        img.sprite = texList[m_skill_number];
        Debug.Log("current value = " + m_skill_number);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.N))
        {
            RenderSprite(++m_skill_number);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            RenderSprite(--m_skill_number);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            m_skill_number = 0;
            RenderSprite(m_skill_number);
        }
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
