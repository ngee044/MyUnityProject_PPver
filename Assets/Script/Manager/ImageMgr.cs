using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eItemType
{
    POTION_TYPE,
    WEAPON_TYPE,
    ETC_TYPE,
    ITEM_TYPE_END,
}

public class ImageMgr : MonoBehaviour
{ 
    private static ImageMgr _instance = null;

    public static ImageMgr GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ImageMgr)) as ImageMgr;
                if (_instance == null)
                    Debug.LogError("CharacterMgr No Active!!!");
            }
            return _instance;
        }
    }

    public List<Texture2D> TextureItem = new List<Texture2D>();
    public GameObject MyPrefabItem;
    public Text MyPrefabItemText;

    List<Sprite> m_EquipList = new List<Sprite>();  //0
    List<Sprite> m_EtcList = new List<Sprite>();    //1
    List<Sprite> m_WeaponList = new List<Sprite>(); //2
    List<Sprite> m_SkillList = new List<Sprite>();  //3

    List<GameObject> m_PrefabObject = new List<GameObject>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        for(int i = 0; i < 16; i++) // 16X16
        {
            for (int j = 0; j < 16; j++)
            {

                m_EquipList.Add(CutRenderValue64x64(TextureItem[0], 16, 16, i, j));
                m_EtcList.Add(CutRenderValue64x64(TextureItem[1], 16, 16, i, j));
                m_WeaponList.Add(CutRenderValue64x64(TextureItem[2], 16, 16, i, j));

            }
        }

        for (int i = 0; i < 6; i++)  // 6X6
        {
            for (int j = 0; j < 6; j++)
            {
                m_SkillList.Add(CutRenderValue82x82(TextureItem[3], 6, 6, i, j));
            }
        }
    }

    public GameObject GetMyPrefab()
    {
        return MyPrefabItem;
    }

    public List<Sprite> GetImageItem(eItemType Type)
    {
        if (Type == eItemType.POTION_TYPE)
        {
            return m_EquipList;
        }
        else if(Type == eItemType.WEAPON_TYPE)
        {
            return m_WeaponList;
        }
        else if(Type == eItemType.ETC_TYPE)
        {
            return m_EtcList;
        }
        else
        {
            Debug.Log("UnKnown Index Value!!");
            return m_EquipList;
        }
    }

    public List<Sprite> GetImageSkill()
    {

        return m_SkillList;
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

    Sprite CutRenderValue82x82(Texture2D _t, int column, int Row, int i, int j)
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

#if false
    Sprite CutRenderHomeWorkVer(Texture2D _t, int column, int Row, int i, int j)
    {
        Sprite sprite;

        j = j % column;

        float rectX = (_t.width / column) * (j);
        float rectY = _t.height - ((_t.height / Row) * (i + 1));
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
#endif


}

