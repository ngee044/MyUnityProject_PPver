using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

    public float Speed = 1000.0f;
    public bool IsBuff;
	// Use this for initialization
	void Start () {
        if (IsBuff)
        {

        }
        else
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        }

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
