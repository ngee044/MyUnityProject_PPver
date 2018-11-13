using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {


    public Texture2D tex;
    public Image img;

    

	// Use this for initialization
	void Start () {
        
        Rect rect = new Rect(0, 0, 82, tex.height);

        img.sprite = Sprite.Create(tex, rect, new Vector2(0,0));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
