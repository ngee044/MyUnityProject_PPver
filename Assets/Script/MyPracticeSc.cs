using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPracticeSc : MonoBehaviour
{
    public List<Animator> ListAnimator = new List<Animator>();
    
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Animator ani in ListAnimator)
                ani.SetTrigger("ATKTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Animator ani in ListAnimator)
                ani.SetTrigger("RUNTrigger");
        }
    }

    void FixedUpdate()
    {

    }

    public void AttackEvent()
    {
        Debug.Log("Attack Event");
    }

    public void RunEvent()
    {
        Debug.Log("RUN EVENT");
    }

}

