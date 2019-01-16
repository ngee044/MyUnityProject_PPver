using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public int Hp;
    public int MaxHp;
    public int Mp;
    public int MaxMp;
    public int atk;

    public Status(int hp, int mp, int Atk)
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
     
    private void Awake()
    {
        player = null;
        eTypeMotion = eEnermyState.Idle;
        rb2D = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        speed = 1f;
        MotionStep = 3;

        status = new Status(50, 10, 1);
    }

    void OnEnable()
    {

    }

    public void StartMove()
    {
        status.Hp = status.MaxHp;
        rb2D.velocity = transform.right * speed;
        Ani.SetBool(AnimationHashList.IsWalkHash, true);
        Ani.SetBool(AnimationHashList.IsWalkHash, false);
        StartCoroutine(EnemyState());
        
    }

    private IEnumerator EnemyState()
    {
        WaitForSeconds pointFive = new WaitForSeconds(.5f);

        while (true)
        {
            switch (eTypeMotion)
            {
                case eEnermyState.Idle:
                    MotionStep--;
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
                        player.Hit(1);
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
    }

    public void Dead()
    {
        this.gameObject.SetActive(false);
    }

    public void Hit(int value)
    {
        status.Hp -= value;
        Debug.Log("Enemy Hit " + value.ToString());
        if(status.Hp <= 0)
        {
            //dead

            Ani.SetBool(AnimationHashList.IsDeadHash, true);
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
            rb2D.velocity = Vector3.zero;
            Ani.SetBool(AnimationHashList.IsWalkHash, false);
            Ani.SetBool(AnimationHashList.IsAttackHash, true);
        }
    }
}
