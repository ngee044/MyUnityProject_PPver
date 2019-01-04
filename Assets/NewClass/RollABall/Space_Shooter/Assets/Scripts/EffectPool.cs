using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eTYPE_EFFECT
{
    ROCK_TYPE,
    ENEMY_TYPE,
    PLAYER_TYPE
}

public class EffectPool : MonoBehaviour {
    public static EffectPool Instance;

    public GameObject[] Prefab;
    private List<GameObject>[] Pool;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Pool = new List<GameObject>[Prefab.Length];
        for(int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = new List<GameObject>();
        }
    }

    public GameObject GetFromPool(int idx)
    {
        for(int i = 0; i < Pool[idx].Count; i++)
        {
            if(!Pool[idx][i].gameObject.activeInHierarchy)
            {
                Pool[idx][i].gameObject.SetActive(true);
                return Pool[idx][i];
            }
        }

        GameObject temp = Instantiate(Prefab[idx]);
        Pool[idx].Add(temp);
        return temp;
    }
}
