using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : MonoBehaviour {
    
    public RockMovement[] Prefab;
    private List<RockMovement>[] Pool;

    void Start()
    {
        Pool = new List<RockMovement>[Prefab.Length];
        for(int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<RockMovement>();
        }
    }

    public RockMovement GetFromPool()
    {
        int idx = Random.Range(0, Prefab.Length);
        for(int i = 0; i < Pool[idx].Count; i++)
        {
            if(!Pool[idx][i].gameObject.activeInHierarchy)
            {
                Pool[idx][i].gameObject.SetActive(true);
                return Pool[idx][i];
            }
        }

        RockMovement temp = Instantiate(Prefab[idx]);
        Pool[idx].Add(temp);
        return temp;
    }
}
