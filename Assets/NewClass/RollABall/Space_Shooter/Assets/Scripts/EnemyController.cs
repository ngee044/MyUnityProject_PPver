using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private float Speed;
    public Transform FirePosition;
    public Bolt boltPrefab;
    public BoltPool boltPool;


    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
        Speed = Random.Range(2.5f, 5.5f);
    }

    private void OnEnable()
    {
        StartCoroutine(EnemyAttack());
        StartCoroutine(Evaid());
        SetDefaultSpeed(); //속도 설정
    }

    void Start() {
    }

    void SetDefaultSpeed()
    {
        rb.velocity = Vector3.back * Speed;
    }

    void SetEvaidMovement()
    {
        float EvaidSpeed = Random.Range(2.5f, 5.5f);

        if (rb.position.x > 0)
        {
            rb.velocity = new Vector3(-EvaidSpeed, 0, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(EvaidSpeed, 0, rb.velocity.z);
        }
    }

    IEnumerator Evaid()
    {
        WaitForSeconds restTime = new WaitForSeconds(0.75f);

        while (true)
        {
            yield return restTime;
            SetEvaidMovement();

            yield return restTime;
            SetDefaultSpeed();
        }
    }

    IEnumerator EnemyAttack()
    {
        while (true)
        {
            WaitForSeconds Delay = new WaitForSeconds(Random.Range(0.8f, 1.2f));

            
            if (boltPool != null)
            {
                Bolt bolt = boltPool.GetFromPool();
                bolt.transform.position = FirePosition.transform.position;
                //bolt.transform.rotation = gameObject.transform.rotation;
            }
            yield return Delay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("PlayerBolt"))
        {
            GameController.Instance.AddScore(1);
            GameObject effect = EffectPool.Instance.GetFromPool((int)eTYPE_EFFECT.ENEMY_TYPE);
            effect.transform.position = this.transform.position;
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void setBoltPool(BoltPool P)
    {
        boltPool = P;
    }
}
