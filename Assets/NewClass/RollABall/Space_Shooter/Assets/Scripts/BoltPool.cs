﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : ObjectPool<Bolt> {

    protected override void Awake()
    {
        base.Awake();
        Debug.Log(OriginArr.Length);

    }
    void Start()
    {
        Pool = new List<Bolt>[OriginArr.Length];
        for (int i = 0; i < OriginArr.Length; i++)
        {
            Pool[i] = new List<Bolt>();
        }
        isLoaded = true;
    }
}
