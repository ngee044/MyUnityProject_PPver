using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemsc {

    public string Name { get; set; }
    public int ItemCost { get; set; }
    public int ItemAbility { get; set; }
    public eItemType ItemType { get; set; }
    public BuyItemType BuyType { get; set; }

    public Itemsc (string name,int cost, int ability, eItemType itemtype, BuyItemType buytype)
    {
        Name = name;
        ItemCost = cost;
        ItemAbility = ability;
        ItemType = itemtype;
        BuyType = buytype;
    }
   
}
