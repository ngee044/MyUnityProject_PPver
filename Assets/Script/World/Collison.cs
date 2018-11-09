using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour {

	private void OnCollisionEnter(Collision rect)
	{
		Debug.Log("Collision");
	}

	private void OnCollisionStay(Collision rect)
	{
		Debug.Log("Collision + ing~");
	}

	private void OnCollisionExit(Collision rect)
	{
		Debug.Log("Collision Exit");
	}
}
