using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator Ani;

    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Ani.SetBool(AnimationHashList.IsAttackHash, true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Ani.SetBool(AnimationHashList.IsAttackHash, false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Ani.SetBool(AnimationHashList.IsDeadHash, true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Ani.SetBool(AnimationHashList.IsDeadHash, false);
        }
    }
}
