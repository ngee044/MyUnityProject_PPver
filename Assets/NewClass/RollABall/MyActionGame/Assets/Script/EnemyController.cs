using System.Collections;
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
    public HpBar bar;
     
    private void Awake()
    {
        player = null;
        eTypeMotion = eEnermyState.Idle;
        rb2D = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        speed = 1f;
        status = new Status(50, 10, 1);
    }

    void OnEnable()
    {

    }

    public void StartMove()
    {
        MotionStep = 3;
        status.Hp = status.MaxHp;
        rb2D.velocity = transform.right * speed;

        Ani.SetBool(AnimationHashList.IsWalkHash, false);
        Ani.SetBool(AnimationHashList.IsDeadHash, false);
        Ani.SetBool(AnimationHashList.IsAttackHash, false);
        StartCoroutine(EnemyState());

        bar = HpBarPool.GetInstacne.GetFromPool();
        bar.transform.position = hpBarPos.position;
        bar.ShowHp(status.Hp / status.MaxHp);
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
        if(bar != null)
        {
            bar.transform.position = hpBarPos.position;
        }
    }

    public void FinishAttack()
    {
        Ani.SetBool(AnimationHashList.IsAttackHash, false);
        player.Hit(1);
    }

    public void Dead()
    {
        this.gameObject.SetActive(false);
    }

    public void Hit(float value)
    {
        status.Hp -= value;
        Debug.Log("Enemy Hit " + value.ToString());

        if (bar != null)
        {
            bar.ShowHp((float)status.Hp / (float)status.MaxHp);
            if (status.Hp <= 0)
            {
                //dead
                eTypeMotion = eEnermyState.Dead;
                bar.gameObject.SetActive(false);
                bar = null;
                Ani.SetBool(AnimationHashList.IsDeadHash, true);
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
