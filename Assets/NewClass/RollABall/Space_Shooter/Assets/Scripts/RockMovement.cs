﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour {

    private float AngularSpeed;
    private Rigidbody rb;
    private float Speed;

    private void Awake()
    {
        Speed = Random.Range(2, 10);
        AngularSpeed = Random.Range(5, 10);
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * AngularSpeed; //회전 속도 설정
        rb.velocity = Vector3.back * Speed; //속도 설정
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || 
            other.gameObject.CompareTag("PlayerBolt"))
        {
            GameController.Instance.AddScore(1);
            GameObject effect = EffectPool.Instance.GetFromPool((int)eTYPE_EFFECT.ROCK_TYPE);
            effect.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
