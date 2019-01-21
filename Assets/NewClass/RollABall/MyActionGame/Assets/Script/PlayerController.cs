using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator Ani;
    private Rigidbody2D rb;
    private Status status;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        status = new Status(500, 100, 30);
    }

    // Update is called once per frame
    void Update()
    {
        float Hori = Input.GetAxis("Horizontal");

        if(Hori < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Hori > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Ani.SetBool(AnimationHashList.IsAttackHash, true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Ani.SetBool(AnimationHashList.IsAttackHash, false);
        }
    }

    public void Hit(float value)
    {
        Debug.Log("Player Hit " + value.ToString());
        status.Hp -= value;
        UIController.GetInstance.ShowHp(value);
        if (status.Hp <= 0 && Ani.GetBool(AnimationHashList.IsDeadHash) == false)
        {
            Ani.SetBool(AnimationHashList.IsDeadHash, true);
            UIController.GetInstance.ShowResultWindow(429496);
        }
        //UIController Send Event
    }

    public void AttackTarget(GameObject target)
    {
        target.SendMessage("Hit", status.atk);
    }
}
