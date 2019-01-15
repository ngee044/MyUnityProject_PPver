using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private EnemyController[] enemyPrefabs;
    private List<EnemyController>[] Pool;

    public static EnemyPool GetInstance;
    private void Awake()
    {
        if (GetInstance == null)
        {
            GetInstance = this;

            //폴더에서 로드
            enemyPrefabs = Resources.LoadAll<EnemyController>("Prefabs/Enemy/");

            Pool = new List<EnemyController>[enemyPrefabs.Length];
            for (int i = 0; i < Pool.Length; i++)
            {
                Pool[i] = new List<EnemyController>();
            }
        }
        else
            Destroy(GetInstance);
    }

    public EnemyController GetFromPool(int index)
    {
        for(int i = 0; i < Pool[index].Count; i++)
        {
            if(!Pool[index][i].gameObject.activeInHierarchy)
            {
                Pool[index][i].gameObject.SetActive(true);
                return Pool[index][i];
            }
        }

        EnemyController newObj = Instantiate(enemyPrefabs[index]);
        Pool[index].Add(newObj);
        return newObj;
    }
}
