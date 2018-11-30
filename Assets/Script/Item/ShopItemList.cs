using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eTypeShop
{
    PotionShop_Type,
    ShopEnd,
}

public class ShopItemList : MonoBehaviour {

    public Button CancelButton;
    public Text MyGoldValue;
    public eTypeShop ShopType;
    public ScrollRect ShopCanvas;
    public GameObject ItemPrefab;

    List<GameObject> ItemObjList = new List<GameObject>();
    List<Sprite> m_ItemSprite= new List<Sprite>();

    // Use this for initialization
    void Start () {
        m_ItemSprite = ImageMgr.GetInstance.GetImageItem(eItemType.POTION_TYPE);
        MyGoldValue.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();

        if (ShopType == eTypeShop.PotionShop_Type)
        {
            CreateShopItem("- HP 포션\n- 50 골드", 12, BuyItemType.HP_Potion);
            CreateShopItem("- MP 포션\n- 50 골드", 62, BuyItemType.MP_Potion);
        }
        else
        {
            Debug.Log("UnKnown ShowType, Value = " + ShopType);
        }
    }

    public void CreateShopItem(string str, int index, BuyItemType item)
    {
        var inst = Instantiate(ItemPrefab); // HP Potion Value;
        string Itemtext = str;
        ItemListScript itemIndex = inst.GetComponent<ItemListScript>();
        itemIndex.SetImage(m_ItemSprite[index], Itemtext, item);
        inst.transform.SetParent(ShopCanvas.content);
        ItemObjList.Add(inst);
    }

    public void on_CancelButton_clicked()
    {
        UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].SetActive(false);
    }
}
