using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    private static ItemUI instance;
    public static ItemUI GetInstance()
    {
        if (!instance)
        {
            instance = GameObject.FindObjectOfType(typeof(ItemUI)) as ItemUI;
            if (!instance)
                Debug.Log("ERROR");
        }

        return instance;
    }

    public Texture2D TextureItem;
    List<Sprite> m_ItemList = new List<Sprite>();

    public Image Hp_Image;
    public Text Hp_Count;
    public Image Mp_Image;
    public Text Mp_Count;

    // Use this for initialization
    void Start () {
 
        for(int i = 0; i < 16; i++)
        {
            for(int j = 0; j < 16; j++)
                m_ItemList.Add(CutRenderValue64x64(TextureItem, 16, 16, i, j));
        }

        Hp_Image.sprite = m_ItemList[12];
        Mp_Image.sprite = m_ItemList[62];
    }

    // Update is called once per frame
    void Update () {
        Hp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion.ToString();
        Mp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion.ToString();

    }

    Sprite CutRenderValue64x64(Texture2D _t, int column, int Row, int i, int j)
    {
        Sprite sprite;
        int x = 64, y = 64;
 
        j = j % column;
        
        float rectX = x * j;
        float rectY = _t.height - (y * (i + 1));
        float rectWidth = x;
        float rectHeight = y;

        Rect rect = new Rect(rectX, rectY, rectWidth, rectHeight);
        sprite = Sprite.Create(_t, rect, new Vector2(0, 0));

        return sprite;
    }
}
