using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if (Speed <= 0)
            Speed = 1.0f;
    }
	
    void ResetBall()
    {
        if (this.transform.position.y <= 0)
        {
            this.transform.position = new Vector3(0, 0.5f, 0);
        }
    }

	// Update is called once per frame
	void Update () {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        //Debug.LogFormat("{0} \n {1}", hori.ToString(), vert.ToString());
        if(Input.GetButtonDown("Fire1"))
        {
        //    gameObject.SetActive(false);
        }

        //rb.AddForce(new Vector3(hori, 0, vert) * Speed);
        rb.velocity = new Vector3(hori, 0,vert) * Speed;
        ResetBall();
    }
}
