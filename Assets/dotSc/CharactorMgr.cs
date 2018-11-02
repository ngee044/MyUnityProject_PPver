using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMgr : MonoBehaviour
{
	int[] m_Arr = new int[5];
	List<ExMove> m_List = new List<ExMove>();
	Dictionary<int, ExMove> m_Dic = new Dictionary<int, ExMove>();

	public int nID;

	public int ID
	{
		set { nID = value; }
		get { return nID; }
	}

	public void CreateChartactor(string Name, int nid)
	{
		int IDnumber = nid;
		string strPath = Name;
		GameObject obj = Resources.Load(strPath) as GameObject;
		obj = GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
		obj.AddComponent<ExMove>();
	}
}
