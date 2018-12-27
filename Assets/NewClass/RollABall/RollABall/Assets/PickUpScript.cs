using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpScript : MonoBehaviour {

    public int Score;
    public float xRot;
    public float yRot;
    public float zRot;

    private GameController control;

    // Use this for initialization
    void Start () {
        GameObject controllerObj = GameObject.FindGameObjectWithTag("GameController");
        control = controllerObj.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime * 5); //오일러 각(선형대수를 공부하자)
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collsion Enter");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            control.AddScore(Score);
            this.transform.position = new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7));
        }
    }
}
