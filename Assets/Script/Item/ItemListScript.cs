using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListScript : MonoBehaviour {

    public Image ItemImage;
    public Text text;
    public Button FocusButton;

    private bool m_focus;
    
    public void SetImage(Sprite sp, string str)
    {
        ItemImage.sprite = sp;
        text.text = str;
    }

    public bool hasfocus
    {
        set{ m_focus = value; }
        get { return m_focus; }
    }
}
