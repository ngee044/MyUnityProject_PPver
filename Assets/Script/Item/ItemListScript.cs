using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BuyItemType
{
    START_BuyType, // Not Focus
    HP_Potion,  //HP potion
    MP_Potion,  //MP potion
    END_BuyType,    //END eType
}

public class ItemListScript : MonoBehaviour {

    public Image ItemImage;
    public Text text;
    BuyItemType Type;
    public Button FocusButton;
    
    public void SetImage(Sprite sp, string str, BuyItemType item)
    {
        ItemImage.sprite = sp;
        text.text = str;
        Type = item;
    }

    public bool CheckPlayerGold(int gold, int cost)
    {
        int curGold = gold;
        curGold =- cost;
        if(curGold < 0)
        {
            MessageBox.Show("소지금 부족", "돈이 부족해 아이템을 구입X", null);
            return false; 
        }
        else
        {
            return true;
        }
    }

    public void on_itemImage_clicked()
    {
        int curGold = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold;

        if (Type == BuyItemType.HP_Potion)
        {
            if (CheckPlayerGold(curGold, 50))
            {
                curGold -= 50;
                CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion++;
            }
        }
        else if(Type == BuyItemType.MP_Potion)
        {
            if (CheckPlayerGold(curGold, 50))
            {
                curGold -= 50;
                CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion++;
            }
        }
        CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold = curGold;
    }
}
