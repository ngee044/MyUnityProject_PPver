using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController GetInstance;

    [SerializeField]
    private Transform LSP, RSP;
    private int EnemyIndexLength;

    private float Money;
    [SerializeField]
    private float income, incomeWeight;
    [SerializeField]
    private int increaseIncomeRate;
    private int spawnCount;

    private void Awake()
    {
        if(GetInstance == null)
        {
            GetInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyIndexLength = EnemyPool.GetInstance.GetIndexCount();
        StartCoroutine(Spawn());
        Money = 0;
        spawnCount = 0;
        UIController.GetInstance.ShowMoney(Money);
    }

    public void AddMoney(float value)
    {
        if(value > 0)
        {
            Money += value;
        }
        PlayerData.GetInstance.AddValue1(3.77f);
        UIController.GetInstance.ShowMoney(Money);
        Debug.Log(Money.ToString("F1"));
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
                newEnemy.StartMove(income+incomeWeight *(spawnCount/increaseIncomeRate));
                spawnCount++;
            }
            yield return oneSec;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
