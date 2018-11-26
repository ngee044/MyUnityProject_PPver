using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemList : MonoBehaviour {

    public Button BuyButton;
    public Button CancelButton;
    public Text MyGoldValue;

    // Use this for initialization
    void Start () {
        MyGoldValue.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
