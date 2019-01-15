using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator Ani;
    private float speed;
    private PlayerController player;

    private void Awake()
    {
        player = null;
        rb2D = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        speed = 1f;
    }

    void OnEnable()
    {
        rb2D.velocity = transform.right * speed;
        Ani.SetBool(AnimationHashList.IsWalkHash, true);
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

    public void Hit(float value)
    {
        Debug.Log("Enemy Hit " + value.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Find Player");
            if(player == null)
                player = collision.gameObject.GetComponent<PlayerController>();

            player.Hit(1);
            rb2D.velocity = Vector3.zero;
            Ani.SetBool(AnimationHashList.IsWalkHash, false);
            Ani.SetBool(AnimationHashList.IsAttackHash, true);
        }
    }
}
