using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExCon : MonoBehaviour {

	public int Speed = 0;
	public int nCount = 0;
	public bool Ischeck = true;
	public bool IscheckAll = true;
	public bool IscheckDic = true;
	public bool IscheckList = true;
	List<GameObject> m_List = new List<GameObject>();
	Dictionary<int, GameObject> m_Dic = new Dictionary<int, GameObject>();
	GameObject[] obj = new GameObject[5];

	// Use this for initialization
	private void Awake()
	{
        
	}

	void Start () {
        string name = "MyPlayer";
		for (int i = 0; i < 5; i++)
		{
			obj[i] = CreateChartactor(name, i);
			m_List.Add(obj[i]);
			m_Dic.Add(i, obj[i]);
			//			m_List.Add(CreateChartactor(name, i));
			//			m_Dic.Add(i, CreateChartactor(name, i));
		}

		StartCoroutine(ClearCoroutine());
	}
    public GameObject CreateChartactor(string Name, int nid)
    {
        int IDnumber = nid;
        string strPath = Name;
        GameObject obj = Resources.Load(strPath) as GameObject;
        obj = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
        obj.AddComponent<ExMove>();

		return obj;
	}
    public void RemoveObj()
	{
		
	}
	// Update is called once per frame
    void Update () {
		
	}

	private void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
			IscheckDic = false;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			IscheckList = false;
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			IscheckAll = false;
		}
	}

	IEnumerator ClearCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f); //1초후 실행
 //			ob.transform.Translate(Vector3.back * 100 * Time.deltaTime);
			if (!IscheckDic)
			{
				if (!(m_Dic.Count == 0))
				{
					Destroy(m_Dic[m_Dic.Count - 1]);
					m_Dic.Remove(m_Dic.Keys.Count - 1);
					Debug.Log("Dictionary Remove " + m_Dic.Keys.Count);
				}
			}

			if (!IscheckList)
			{
				if (!(m_List.Count == 0))
				{
					Destroy(m_List[m_List.Count - 1]);
					m_List.Remove(m_List[m_List.Count - 1]);
					Debug.Log("List Remove " + m_List.Count);
				}
			}
			
			if(!IscheckAll)
			{

			}

			if (m_List.Count == 0 && m_Dic.Keys.Count == 0)
			{
				Debug.Log("RemoveAll Succese");
				break;
			}         
		}
	}
}

