using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Texture2D Skill_Texture;
    List<Sprite> texList = new List<Sprite>();
    public Image img;
    int num = 0;

    void RenderSprite(int n)
    {
        if (texList.Count < n + 1)
            n = num = 0;
        else if (n < 0) num = n = texList.Count - 1;

        img.sprite = texList[n];
    }

    // Use this for initialization
    void Start () {

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
                texList = ImageMgr.GetInstance.GetImageSkill();
        }
        RenderSprite(num);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.N))
        {
            RenderSprite(++num);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            RenderSprite(--num);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            num = 0;
            RenderSprite(num);
        }
    }
}
