using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Texture2D tex;
    public List<Texture2D> texList;
    public Image img;
    public Image img2;

    int i, j, n;
    
    void RenderSprite()
    {
        // if (_IsInput == false) return;

        img.sprite = CutRenderValue82x82(texList[n], 6, 6);
        img2.sprite = CutRenderValue82x82(tex, 6, 6);
    }

    // Use this for initialization
    void Start () {
        i = 0;
        j = 0;
        n = 0;

        img.sprite = CutRenderValue82x82(texList[n], 6, 6);
        img2.sprite = CutRenderValue82x82(tex, 6, 6);        
    }

    Sprite CutRenderHomeWorkVer(Texture2D _t, int Row, int column)
    {
        Sprite sprite;

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

    Sprite CutRenderValue64x64(Texture2D _t, int column, int Row)
    {
        Sprite sprite;
        int x = 64, y = 64;

        float rectX = x * (j);
        float rectY = y - ((y / Row) * (i + 1));
        float rectWidth = x / Row;
        float rectHeight = y / column;

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
    }

    Sprite CutRenderValue82x82(Texture2D _t, int column, int Row)
    {
        Sprite sprite;
        int x = 82, y = 82;

        float rectX = x * (j);
        float rectY = _t.height - (y * (i + 1));
        float rectWidth = x;
        float rectHeight = y;

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
    }

    Sprite CutRenderValue128x128(Texture2D _t, int column, int Row)
    {
        Sprite sprite;
        int x = 128, y = 128;

        float rectX = x * (j);
        float rectY = y - ((y / Row) * (i + 1));
        float rectWidth = x / Row;
        float rectHeight = y / column;

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
    }

    // Update is called once per frame
    void Update () {



        if (Input.GetKeyDown(KeyCode.N))
        {
            RenderSprite();
            j++;
            if (j >= 6)
            {
                i++;
                j = 0;
            }
            if (i >= 6) i = 0;
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            RenderSprite();
            n++;
            if (n > 2) n = 0;
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            RenderSprite();
            i = j = n = 0;
        }
    }
}
