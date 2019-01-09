using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public BoltPool BoltPool;
    public EnemyController Prefab;
    public ItemPool itemPool;
    private List<EnemyController> Pool;

    void Start()
    {
        Pool = new List<EnemyController>();
    }

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }

        EnemyController temp = Instantiate(Prefab);
        temp.setBoltPool(BoltPool);
        temp.SetItemPool(itemPool);
        Pool.Add(temp);
        return temp;
    }
}
