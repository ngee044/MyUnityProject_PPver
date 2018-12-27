using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject MyPlayer;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        MyPlayer = GameObject.FindGameObjectWithTag("Player");
        offset = MyPlayer.transform.position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = MyPlayer.transform.position - offset;
	}
}
