using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public RockMovement RockPrefabs;
    private const float RELOAD_TIME = 5;
    private float currentReloadTime;

    private Coroutine routine;

	// Use this for initialization
	void Start () {
        currentReloadTime = 0;
        //StartCoroutine(SpawnRoutine());
        routine = StartCoroutine(SpawnRoutine(1.0f));
        
    }

    private IEnumerator Test()
    {
        while (true)
        {
            Debug.Log("^^^^");
            yield return new WaitForSeconds(3);
            Debug.Log("#$#$#$");
        }
    }


    private IEnumerator SpawnRoutine(float contineue)
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                RockMovement newAst = Instantiate(RockPrefabs);
                newAst.transform.position = new Vector3(Random.Range(-5, 5), 0, 16); //위치 설정
                //위치 배치 (x = -5 ~ 5/ z = 16)
                yield return new WaitForSeconds(0.3f);
            }
            yield return new WaitForSeconds(RELOAD_TIME);
        }
    }

	// Update is called once per frame
	void Update () {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (routine != null)
            {
                StopCoroutine(routine);
                routine = null;
            }
            else if (routine == null)
            {
                routine = StartCoroutine(SpawnRoutine(1.0f));
            }

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(routine != null);
        }
        //gameObject.SetActive(false);
        ////~~~~~~~
        //gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        routine = null;
    }
}
