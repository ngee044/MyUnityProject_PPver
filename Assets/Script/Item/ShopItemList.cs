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

    public Button BuyButton;
    public Button CancelButton;
    public Text MyGoldValue;
    public eTypeShop ShopType;
    public ScrollRect ShopCanvas;
    public GameObject ItemPrefab;

    private List<GameObject> ItemObjList = new List<GameObject>();
    public Button ItemSelectButton;

    List<Sprite> m_ItemSprite= new List<Sprite>();
    List<GameObject> m_obj = new List<GameObject>();

    // Use this for initialization
    void Start () {
        m_obj.Add(ImageMgr.GetInstance.GetMyPrefab());
        m_ItemSprite = ImageMgr.GetInstance.GetImageItem(eItemType.POTION_TYPE);
        MyGoldValue.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();

#if false
        var inst = Instantiate(ItemList[0]); // HP Potion Value;
        string Itemtext = "- HP 포션\n- HP 50 회복";
        ItemListScript itemIndex = inst.GetComponent<ItemListScript>();
        itemIndex.SetImage(m_ItemSprite[12], Itemtext);
        inst.transform.SetParent(ShopCanvas.content);

        var inst2 = Instantiate(ItemList[1]); // HP Potion Value;
        string Itemtext2 = "- MP 포션\n- MP 50 회복";
        //ItemListScript itemIndex2 = inst2.GetComponent<ItemListScript>();
        itemIndex = inst2.GetComponent<ItemListScript>();
        itemIndex.SetImage(m_ItemSprite[62], Itemtext2);
        inst2.transform.SetParent(ShopCanvas.content);
#endif
        if (ShopType == eTypeShop.PotionShop_Type)
        {
            CreateShopItem("- HP 포션\n- HP 50 회복", 12);
            CreateShopItem("- MP 포션\n- MP 50 회복", 62);
        }
        else
        {
            Debug.Log("UnKnown ShowType, Value = " + ShopType);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void CreateShopItem(string str, int index)
    {
        var inst = Instantiate(ItemPrefab); // HP Potion Value;
        string Itemtext = str;
        ItemListScript itemIndex = inst.GetComponent<ItemListScript>();
        itemIndex.SetImage(m_ItemSprite[index], Itemtext);
        inst.transform.SetParent(ShopCanvas.content);
        ItemObjList.Add(inst);
    }

    public void on_BuyButton_clicked()
    {
        Debug.Log("Clicked BuyButton");
        int current_Gold = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold;
        if(ItemObjList[0])
        {
            Debug.Log("Buy");
            CharacterMgr.GetInstance.GetPlayer.PlayerItem.HP_Potion++;
        }
        else if(ItemObjList[2])
        {
            CharacterMgr.GetInstance.GetPlayer.PlayerItem.MP_Potion++;
        }
    }

    public void on_CancelButton_clicked()
    {
        UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].SetActive(false);
    }
}
