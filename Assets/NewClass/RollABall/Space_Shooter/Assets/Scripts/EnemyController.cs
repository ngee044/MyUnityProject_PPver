﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private float Speed;
    public Transform FirePosition;
    public Bolt boltPrefab;
    public BoltPool boltPool;
    public ItemPool itemPool;
    private PlayerController player;

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

    private void OnDisable()
    {
        GameController.Instance.AddScore(1);
        GameObject effect = EffectPool.Instance.GetFromPool((int)eTYPE_EFFECT.ENEMY_TYPE);
        effect.transform.position = this.transform.position;
        SoundController.Instance.PlayeEffectSound(eEffectClips.ExpEnemy);

        int getItem = 0;
        getItem = Random.Range(0, 100);
        if (getItem <= 30)
        {
            int idx = Random.Range(0, 2);
            ItemMovement newItem = itemPool.GetFromPool(idx);
            newItem.transform.position = this.transform.position;
        }
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
                Bolt bolt = boltPool.GetFromPool(0);
                SoundController.Instance.PlayeEffectSound(eEffectClips.WeaponEnemy);
                bolt.transform.position = FirePosition.transform.position;
            }
            yield return Delay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("PlayerBolt"))
        {            
            if (other.gameObject.CompareTag("Player"))
            {
                if(player == null)
                {
                    player = other.gameObject.GetComponent<PlayerController>();
                }
                player.Hit(1);
            }
            else
            {
                other.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }

    public void setBoltPool(BoltPool P)
    {
        boltPool = P;
    }

    public void SetItemPool(ItemPool P)
    {
        itemPool = P;
    }
}
