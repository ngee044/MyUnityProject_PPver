using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : ObjectPool<ItemMovement> {

    protected override void Awake()
    {
        base.Awake();
        Debug.Log(OriginArr.Length);
    }

    void Start()
    {
        Pool = new List<ItemMovement>[OriginArr.Length];
        for (int i = 0; i < OriginArr.Length; i++)
        {
            Pool[i] = new List<ItemMovement>();
        }
        isLoaded = true;
    }
}
