using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
            Destroy(collision.gameObject);
        else if (collision.collider.tag == "skill")
            Destroy(collision.gameObject);
    }
}
