using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarPool : MonoBehaviour
{
    [SerializeField]
    private Transform canvas;
    private HpBar barPrefab;
    private List<HpBar> Pool;

    public static HpBarPool GetInstacne;

    private void Awake()
    {
        if(GetInstacne == null)
        {
            GetInstacne = this;
            Pool = new List<HpBar>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public HpBar GetFromPool()
    {
        HpBar newlist = Instantiate(barPrefab);

        return newlist;
    }
}
