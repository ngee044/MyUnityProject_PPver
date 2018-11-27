using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    public Image Hp_Image;
    public Text Hp_Count;
    public Image Mp_Image;
    public Text Mp_Count;

    List<Sprite> m_ItemList = new List<Sprite>();

    // Use this for initialization
    void Start () {
        m_ItemList = ImageMgr.GetInstance.GetImageItem(eItemType.POTION_TYPE);

        Hp_Image.sprite = m_ItemList[12]; // HP Potion Value;
        Mp_Image.sprite = m_ItemList[62]; // MP Potion Value;
    }

    // Update is called once per frame
    void Update () {
        Hp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion.ToString();
        Mp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion.ToString();

    }

}
