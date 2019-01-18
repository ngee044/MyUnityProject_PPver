using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform LSP, RSP;
    private int EnemyIndexLength;
    
    // Start is called before the first frame update
    void Start()
    {
        EnemyIndexLength = EnemyPool.GetInstance.GetIndexCount();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds oneSec = new WaitForSeconds(3);
        while(true)
        {
            if (false)//(count > MaxEnemyCount)
            {

            }
            else
            {
                int SelectPos = Random.Range(0, 2);
                int index = Random.Range(0, EnemyIndexLength); // 0,2
                EnemyController newEnemy = EnemyPool.GetInstance.GetFromPool(index);
                if (SelectPos == 0) //Left
                {
                    newEnemy.transform.position = LSP.position;
                    newEnemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    newEnemy.transform.position = RSP.position;
                    newEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                newEnemy.StartMove();
            }
            yield return oneSec;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
