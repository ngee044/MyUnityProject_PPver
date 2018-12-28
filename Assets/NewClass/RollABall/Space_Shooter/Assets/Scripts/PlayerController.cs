using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public float TiltAmount;
    public float xMax, xMin;
    public float zMax, zMin;

    Bolt bolt;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        if (Speed <= 9)
            Speed = 10;

        if (TiltAmount < 30)
            TiltAmount = 30;
    }
	
	// Update is called once per frame
	void Update () {
        float Hori = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(Hori, 0, Vert) * Speed;
        transform.rotation = Quaternion.Euler(0, 0, Hori * -TiltAmount);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), 0, Mathf.Clamp(rb.position.z, zMin, zMax));
        if(Input.GetKeyDown("Fire"))
        {
            
        }
    }
}
