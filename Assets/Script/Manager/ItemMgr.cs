using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour {


    public static ItemMgr GetInstance;

    List<Itemsc> Item = new List<Itemsc>();

    private void Awake()
    {
        if(ItemMgr.GetInstance == null)
            ItemMgr.GetInstance = this;
    }

    public void CreateItem()
    {
        Itemsc item = new Itemsc("HP_Potion", 50, 50, eItemType.POTION_TYPE, BuyItemType.HP_Potion);
    }
}
