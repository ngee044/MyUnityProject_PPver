using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public UIController uiController;
    public RockMovement[] RockPrefabs;
    private const float RELOAD_TIME = 5;
    private float currentReloadTime;

    private Coroutine routine;

    public EnemyPool enemyPool;
    public RockPool rockPool;
    public BGScroller[] BGs;

    private int score;
    public GameObject Player;

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
        SoundController.Instance.PlayeBGM(eBGMClips.BG01_BACKGROUND);
        //routine = StartCoroutine(SpawnRoutine(1.0f));
    }

    private IEnumerator SpawnRoutine()
    {
        WaitForSeconds PointThree = new WaitForSeconds(0.3f);
        WaitForSeconds ReloadTime = new WaitForSeconds(RELOAD_TIME);
        int enemyCount = 3;
        int RockCount = 5;
        while (true)
        {
            if(enemyCount > 0 && RockCount > 0)
            {
                int currentRand = Random.Range(0, 2);
                if(currentRand == 0)
                {
                    RockMovement newAst = rockPool.GetFromPool();
                    newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16); //위치 설정
                    RockCount--;
                    yield return PointThree;
                }
                else
                {
                    EnemyController newEnemy = enemyPool.GetFromPool();
                    newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                    enemyCount--;
                    yield return PointThree;
                }
            }
            else if(enemyCount > 0)
            {
                EnemyController newEnemy = enemyPool.GetFromPool();
                newEnemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                enemyCount--;
                RockCount = 5;
                yield return PointThree;
            }
            else
            {
                RockMovement newAst = rockPool.GetFromPool();
                newAst.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16); //위치 설정
                RockCount--;
                enemyCount = 3;
                yield return PointThree;
            }
            //yield return ReloadTime;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        uiController.ShowScore(score);
    }

    public void GameOver()
    {
        uiController.ShowSatusMessage("Game Over...");
        uiController.RestartButton.gameObject.SetActive(true);
        if (routine != null)
        {
            StopCoroutine(routine);
            for(int i = 0; i < BGs.Length; i++)
            {
                BGs[i].SetSpeed(0);
            }
        }
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

    public void on_ResetButton_clicked()
    {
        SceneManager.LoadScene(0);
        //routine = StartCoroutine(SpawnRoutine());
        //uiController.ShowSatusMessage("");
        //uiController.ShowScore(0);
        //for (int i = 0; i < BGs.Length; i++)
        //{
        //    BGs[i].SetSpeed(2);
        //}
        //Player.SetActive(true);
        //Player.transform.position = new Vector3(0, 0, 0);
    }
}
