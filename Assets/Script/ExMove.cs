using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExMove : MonoBehaviour {

    public int InputCnt = 0;
    public int Speed = 50;

	private void Awake()
    {
        //Do First function
    }

    // Use this for initialization
    void Start () {

    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //}
        //else if(Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * Speed * Time.deltaTime);
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * Speed * Time.deltaTime);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * Speed * Time.deltaTime);
        //}
    }

    // Update is called once per frame
    void Update () {

    }

}
