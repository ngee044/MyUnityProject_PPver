using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eItemType
{
    powerUp, Life
}
public class ItemMovement : MonoBehaviour {

    private float AngularSpeed;
    private Rigidbody rb;
    private float Speed;
    private PlayerController player;
    public eItemType itemType; 

    private void Awake()
    {
        Speed = Random.Range(5, 7);
        AngularSpeed = Random.Range(7, 12);
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * AngularSpeed; //회전 속도 설정
        rb.velocity = Vector3.back * Speed; //속도 설정
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player == null)
                player = other.gameObject.GetComponent<PlayerController>();

            player.GetItem(itemType);
            gameObject.SetActive(false);
        }
    }
}
