using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

    public int Damage = 20;
    public float Speed = 1000.0f;


	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);

        StartCoroutine(destroyBullet());

    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
