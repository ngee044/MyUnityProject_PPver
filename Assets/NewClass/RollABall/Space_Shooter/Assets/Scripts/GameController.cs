using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;

    public RockMovement[] RockPrefabs;
    private const float RELOAD_TIME = 5;
    private float currentReloadTime;

    private Coroutine routine;

    public EnemyPool enemyPool;
    public RockPool rockPool;

    private int score;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        currentReloadTime = 0;
        score = 0;
        routine = StartCoroutine(SpawnRoutine());
        //routine = StartCoroutine(SpawnRoutine(1.0f));
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds PointThree = new WaitForSeconds(0.3f);
        WaitForSeconds ReloadTime = new WaitForSeconds(RELOAD_TIME);

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                RockMovement newAst = rockPool.GetFromPool();
                newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16); //위치 설정
                //위치 배치 (x = -5 ~ 5/ z = 16)
                yield return PointThree;
            }

            for(int i= 0; i < 2; i++)
            {
                var newEnemy = enemyPool.GetFromPool();
                newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                yield return PointThree;
            }

            yield return ReloadTime;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        StopCoroutine(routine);
    }

	// Update is called once per frame
	void Update () {
        #region Study Code
        //if (currentReloadTime <= 0)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        RockMovement newAst = Instantiate(RockPrefabs);
        //        newAst.transform.position = new Vector3(Random.Range(-5, 5), 0, 16);
        //        //위치 배치 (x = -5 ~ 5/ z = 16)
        //    }
        //    Debug.Log(Time.time);
        //    currentReloadTime = RELOAD_TIME;
        //}
        //else
        //{
        //    currentReloadTime -= Time.deltaTime;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (routine != null)
        //    {
        //        StopCoroutine(routine);
        //        routine = null;
        //    }
        //    else if (routine == null)
        //    {
        //        routine = StartCoroutine(SpawnRoutine());
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log(routine != null);
        //}
        //gameObject.SetActive(false);
        ////~~~~~~~
        //gameObject.SetActive(true);
        #endregion
    }

    private void OnDisable()
    {
        routine = null;
    }
}
