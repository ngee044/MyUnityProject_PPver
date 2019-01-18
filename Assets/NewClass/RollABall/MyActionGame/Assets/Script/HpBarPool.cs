using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarPool : MonoBehaviour
{
    [SerializeField]
    private Transform canvas;

    public HpBar barPrefab;
    private List<HpBar> Pool;

    public static HpBarPool GetInstacne;

    private void Awake()
    {
        if(GetInstacne == null)
        {
            GetInstacne = this;
            Pool = new List<HpBar>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    

    public HpBar GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }

        HpBar newlist = Instantiate(barPrefab,canvas);
        Pool.Add(newlist);
        return newlist;
    }
}
