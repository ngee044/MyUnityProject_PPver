using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
    private const float tagDis = 40.94f; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BGbumper"))
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + tagDis);
        }
    }

    public void SetSpeed(float value)
    {
        Speed = value;
        rb.velocity = Vector3.back * Speed;
    }
}
