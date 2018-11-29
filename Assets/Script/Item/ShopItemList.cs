using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemList : MonoBehaviour {

    public Button BuyButton;
    public Button CancelButton;
    public Text MyGoldValue;

    public ScrollRect ShopCanvas;
    public List<GameObject> ItemList = new List<GameObject>();

    List<Sprite> m_ItemSprite= new List<Sprite>();
    List<GameObject> m_obj = new List<GameObject>();

    // Use this for initialization
    void Start () {
        m_obj.Add(ImageMgr.GetInstance.GetMyPrefab());
        m_ItemSprite = ImageMgr.GetInstance.GetImageItem(eItemType.POTION_TYPE);
        MyGoldValue.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();

        var inst = Instantiate(ItemList[0]); // HP Potion Value;
        
        inst.transform.SetParent(ShopCanvas.content);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void on_BuyButton_clicked()
    {
        int current_Gold = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold;

    }

    public void on_CancelButton_clicked()
    {
        UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].SetActive(false);
    }
}
