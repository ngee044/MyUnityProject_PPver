using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour {

    private float AngularSpeed;
    private Rigidbody rb;
    private float Speed;
    private PlayerController player;
    public ItemPool itemPool;

    private void Awake()
    {
        Speed = Random.Range(2, 10);
        AngularSpeed = Random.Range(5, 10);
        rb = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        GameController.Instance.AddScore(1);
        GameObject effect = EffectPool.Instance.GetFromPool((int)eTYPE_EFFECT.ROCK_TYPE);
        effect.transform.position = this.transform.position;
        SoundController.Instance.PlayeEffectSound(eEffectClips.ExpRock);

        int getItem = 0;
        getItem = Random.Range(0, 100);
        if (getItem <= 30)
        {
            int idx = Random.Range(0, 2);
            ItemMovement newItem = itemPool.GetFromPool(idx);
            newItem.transform.position = this.transform.position;
        }
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
            if (other.gameObject.CompareTag("Player"))
            {
                if (player == null)
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

    public void SetItemPool(ItemPool P)
    {
        itemPool = P;
    }
}
