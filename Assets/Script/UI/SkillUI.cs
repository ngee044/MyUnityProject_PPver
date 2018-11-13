using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {


    public Texture2D tex;
    public List<Texture2D> texList;
    public Image img;
    public Image img2;

    float _Stime;
    float _Etime;
    int i, j, n, k, o;
	// Use this for initialization
	void Start () {
        i = 0;
        j = 0;
        n = 0;
        k = 0;
    }
	
	// Update is called once per frame
	void Update () {

        img2.sprite = Sprite.Create(tex, new Rect((82 * (j)), tex.height - (82 * (i+1)), 82, 82), new Vector2(0, 0));
        img.sprite = Sprite.Create(texList[n], new Rect((82 * (j)), tex.height - (82 * (i + 1)), 82, 82), new Vector2(0, 0));

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
