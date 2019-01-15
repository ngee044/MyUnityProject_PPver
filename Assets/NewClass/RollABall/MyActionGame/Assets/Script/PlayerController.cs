using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator Ani;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Hori = Input.GetAxis("Horizontal");

        if(Hori < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
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
    }

    public void AttackTarget(GameObject target)
    {
        target.SendMessage("Hit", 1);
    }
}
