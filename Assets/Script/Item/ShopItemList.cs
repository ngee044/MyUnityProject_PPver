using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemList : MonoBehaviour {

    public Button BuyButton;
    public Button CancelButton;
    public Text MyGoldValue;
    public ScrollRect ShopCanvas;

    List<Sprite> m_ItemList = new List<Sprite>();
    List<GameObject> m_obj = new List<GameObject>();

    // Use this for initialization
    void Start () {
        m_obj.Add(ImageMgr.GetInstance.GetMyPrefab());
        m_ItemList = ImageMgr.GetInstance.GetImageItem(eItemType.POTION_TYPE);
        MyGoldValue.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();

        var inst = Instantiate(m_obj[0]); // HP Potion Value;
        inst.transform.SetParent(ShopCanvas.content);

        
    }
	
	// Update is called once per frame
	void Update () {

	}
}
