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
                texList.Add(CutRenderValue82x82(Skill_Texture, 6, 6, i, j));
        }
        RenderSprite(num);
    }

    Sprite CutRenderHomeWorkVer(Texture2D _t, int column, int Row, int i, int j)
    {
        Sprite sprite;

        j = j % column;

        float rectX = (_t.width / column) * (j);
        float rectY = _t.height -( (_t.height / Row) * (i + 1) );
        float rectWidth = _t.width / Row;
        float rectHeight = _t.height / column;

        Debug.Log("X = " + rectX);
        Debug.Log("Y = " + rectY);
        Debug.Log("Width = " + rectWidth);
        Debug.Log("Height = " + rectHeight);

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
    }


    Sprite CutRenderValue82x82(Texture2D _t, int column, int Row,int i, int j)
    {
        Sprite sprite;
        int x = 82, y = 82;

        j = j % column;

        float rectX = x * (j);
        float rectY = _t.height - (y * (i + 1));
        float rectWidth = x;
        float rectHeight = y;

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
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
