using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour {

    public GameObject Prefab { get; set; }
    private List<T> Pool;

    // Use this for initialization
    void Start () {
        Pool = new List<T>();
    }

#if false
    public T GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }

        T temp = Instantiate(Prefab);
        Pool.Add(temp);
        return temp;
    }
#endif
}
