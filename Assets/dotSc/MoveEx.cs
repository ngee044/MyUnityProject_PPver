using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    int m_nID;
    public int InputCnt = 0;
    public int Speed = 30;

    public int ID
    {
        set { m_nID = value; }
        get { return m_nID; }
    }

    private void Awake()
    {
        //Do First function
    }

    // Use this for initialization
    void Start () {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
            InputCnt++;
            Debug.Log("input Key W Down");

            if (InputCnt >= 5)
            {
                InputCnt = 0;
                transform.gameObject.SetActive(false);
                Debug.Break();
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }

}
