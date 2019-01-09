using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component {

    [SerializeField]
    protected T[] OriginArr;
    protected List<T>[] Pool;
    public bool IsLoaded
    {
        get { return isLoaded; }
    }
    protected bool isLoaded;

    protected virtual void Awake()
    {
        isLoaded = false;
    }

    protected void SetPoolOrigin<A> (string path) where A : T
    {
        OriginArr = Resources.LoadAll<A>(path);
        Pool = new List<T>[OriginArr.Length];
        for(int i = 0; i< OriginArr.Length; i++)
        {
            Pool[i] = new List<T>();
        }
        isLoaded = true;
    }

    public virtual T GetFromPool(int idx)
    {
        for (int i = 0; i < Pool[idx].Count; i++)
        {
            if (!Pool[idx][i].gameObject.activeInHierarchy)
            {
                Pool[idx][i].gameObject.SetActive(true);
                return Pool[idx][i];
            }
        }

        T temp = Instantiate(OriginArr[idx]);
        Pool[idx].Add(temp);
        return temp;
    }
}
