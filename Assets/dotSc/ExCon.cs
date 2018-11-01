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
        string name = "MyPlayer";
        CreateChartactor(name, 0);
        //CharactorMgr.Instance.CreateChartactor(name, 0);
    }
    public void CreateChartactor(string Name, int nid)
    {
        int IDnumber = nid;
        string strPath = Name;
        GameObject obj = Resources.Load(strPath) as GameObject;
        obj = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
        obj.AddComponent<ExMove>();
        ob = obj;
    }
    // Update is called once per frame
    void Update () {
		
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyUp(KeyCode.Q))
		{
            StartCoroutine(ClearCoroutine());
		}
	}

	IEnumerator ClearCoroutine()
	{
		while (true)
		{
			nCount++;
			yield return new WaitForSeconds(1f); //1초후 실행			
			ob.transform.Translate(Vector3.back * 100 * Time.deltaTime);
            if (nCount > 5)
            {
                nCount = 0;
                break;
            }
		}
	}
}

