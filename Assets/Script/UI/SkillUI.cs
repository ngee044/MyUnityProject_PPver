using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Texture2D tex;
    public List<Texture2D> texList;
    public Image img;
    public Image img2;
    bool _IsInput;

    float _Stime;
    float _Etime;
    int i, j, n, k, o;

    Sprite CutRender(Texture2D tex, int Row, int column)
    {
        Sprite image;
       
        Rect rect = new Rect( (tex.width/column * (j)), tex.height - (tex.height/Row * (i + 1)) ,82,82);
        image.sprite = Sprite.Create(tex, rect, new Vector2(0, 0));
        
        return image.sprite;
    }

    void RenderSprite()
    {
        if (_IsInput == false) return;

        img.sprite = CutRender(tex, 6, 6);
        img2.sprite = CutRender(tex, 6, 6);

    }

    // Use this for initialization
    void Start () {
        _IsInput = false;
        i = 0;
        j = 0;
        n = 0;
        k = 0;
    }
	
	// Update is called once per frame
	void Update () {

        RenderSprite();

        if (Input.GetKeyDown(KeyCode.N))
        {
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
            n++;
            if (n > 2) n = 0;

        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            i = j = n = k = 0;
        }
	}
}
