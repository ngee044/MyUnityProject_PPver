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

        foreach(var list in m_ItemList)
        {
            Debug.Log(list);
        }

        Hp_Image.sprite = m_ItemList[12]; // HP Potion Value;
        Mp_Image.sprite = m_ItemList[62]; // MP Potion Value;
    }

    // Update is called once per frame
    void Update () {
        Hp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion.ToString();
        Mp_Count.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion.ToString();

    }

    public void on_ItemMP_clicked()
    {
        int curItemCount = CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion;

        if (curItemCount > 0)
        {
            int curPlayerMP = CharacterMgr.GetInstance.GetPlayer.MP;
            int Max = CharacterMgr.GetInstance.GetPlayer.MPMAX;

            if (curPlayerMP >= Max) return;

            CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion = curItemCount - 1;

            curPlayerMP += 50;
            if (Max < curPlayerMP)
                curPlayerMP = Max;

            CharacterMgr.GetInstance.GetPlayer.MP = curPlayerMP;
        }
        else
            return;
    }

    public void on_ItemHP_clicked()
    {
        int curItemCount = CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion;

        if (curItemCount > 0)
        {
            int curPlayerHP = CharacterMgr.GetInstance.GetPlayer.HP;
            int Max = CharacterMgr.GetInstance.GetPlayer.HPMAX;

            if (curPlayerHP >= Max) return;

            CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion = curItemCount - 1;

            curPlayerHP += 50;
            if (Max < curPlayerHP)
                curPlayerHP = Max;

            CharacterMgr.GetInstance.GetPlayer.HP = curPlayerHP;
        }
        else
            return;
    }

}
