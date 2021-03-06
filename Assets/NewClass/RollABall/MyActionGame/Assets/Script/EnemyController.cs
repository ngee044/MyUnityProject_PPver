﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public float Hp { get; set; }
    public float MaxHp { get; set; }
    public float Mp { get; set; }
    public float MaxMp { get; set; }
    public float atk { get; set; }

    public Status(float hp, float mp, float Atk)
    {
        Hp = MaxHp = hp;
        Mp = MaxMp = mp;
        atk = Atk;
    }
}

public enum eEnermyState
{
    Idle,
    Walk,
    Attack,
    Dead,
    END
}

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator Ani;

    private float speed;

    private PlayerController player;
    private Status status;
    private eEnermyState eTypeMotion;
    private int MotionStep;

    public Transform hpBarPos;

    private float incomeAmount;
    [SerializeField]
    private float incomeWeight;
    
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        status = new Status(50, 10, 1);
    }

    void OnEnable()
    {
        if(status.Hp <= 0)
            status.Hp = status.MaxHp;
    }

    public void StartMove(float inputIncome)
    {
        MotionStep = 3;
        status.Hp = status.MaxHp;

        incomeAmount = inputIncome * incomeWeight;

        eTypeMotion = eEnermyState.Idle;
        speed = 1f;
        Ani.SetBool(AnimationHashList.IsWalkHash, false);
        Ani.SetBool(AnimationHashList.IsDeadHash, false);
        Ani.SetBool(AnimationHashList.IsAttackHash, false);
        StartCoroutine(EnemyState());
    }

    private IEnumerator EnemyState()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);

        while (true)
        {
            MotionStep--;
            switch (eTypeMotion)
            {
                case eEnermyState.Idle:
                    if (MotionStep <= 0)
                    {
                        eTypeMotion = eEnermyState.Walk;
                        rb2D.velocity = transform.right * speed;
                        Ani.SetBool(AnimationHashList.IsWalkHash, true);
                        MotionStep = 4;
                    }
                    break;
                case eEnermyState.Walk:
                    if (MotionStep <= 0)
                    {
                        eTypeMotion = eEnermyState.Idle;
                        rb2D.velocity = Vector3.zero;
                        Ani.SetBool(AnimationHashList.IsWalkHash, false);
                        MotionStep = 3;
                    }
                    break;
                case eEnermyState.Attack:
                    if (MotionStep <= 0)
                    {
                        Ani.SetBool(AnimationHashList.IsAttackHash, true);
                        MotionStep = 2;
                    }
                    break;
                case eEnermyState.Dead:
                    if (MotionStep <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                default:
                    {
                        Debug.Log("UnKnown Type " + eTypeMotion);
                    }
                    break;
            }
            yield return pointFive;
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FinishAttack()
    {
        Ani.SetBool(AnimationHashList.IsAttackHash, false);
        player.Hit(1);
    }

    public void Hit(float value)
    {
        status.Hp -= value;
        Debug.Log("Enemy Hit " + value.ToString());
        
        if (!Ani.GetBool(AnimationHashList.IsDeadHash))
        {
            HpBar bar = HpBarPool.GetInstacne.GetFromPool();
            bar.transform.position = hpBarPos.position;
            bar.ShowHp(status.Hp / status.MaxHp);

            if (status.Hp <= 0)
            {
                //dead
                bar.ShowIncom(incomeAmount);
                eTypeMotion = eEnermyState.Dead;
                Ani.SetBool(AnimationHashList.IsDeadHash, true);

                GameController.GetInstance.AddMoney(incomeAmount);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Find Player");
            if(player == null)
                player = collision.gameObject.GetComponent<PlayerController>();

            player.Hit(1);
            eTypeMotion = eEnermyState.Attack;
            MotionStep = 2;
            Ani.SetBool(AnimationHashList.IsWalkHash, false);
            Ani.SetBool(AnimationHashList.IsAttackHash, true);
            
            //rb2D.velocity = Vector3.zero;
        }
    }
}
