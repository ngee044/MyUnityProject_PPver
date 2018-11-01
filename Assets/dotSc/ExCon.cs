using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExCon : MonoBehaviour {

	public int Speed = 0;
	public int nCount = 0;
	GameObject ob;
	// Use this for initialization
	private void Awake()
	{


	}

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void getResource(string Name)
	{
		string strPath = Name;
		GameObject obj = Resources.Load(strPath) as GameObject;
		obj = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
		obj.AddComponent<ExCon>();
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			getResource("MyPlayer");

			StartCoroutine(ClearCoroutine());
		}
	}

	IEnumerator ClearCoroutine()
	{
		while (true)
		{
			nCount++;
			yield return new WaitForSeconds(1f); //1초후 실행
			
			transform.Translate(Vector3.back * Speed * Time.deltaTime);
			if (nCount > 5)
				break;
		}
	}
}

