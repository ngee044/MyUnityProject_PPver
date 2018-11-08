using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

	private static SoundMgr instance;
	public static SoundMgr GetInstance()
	{
		if (!instance)
		{
			instance = GameObject.FindObjectOfType(typeof(SoundMgr)) as SoundMgr;
			if (!instance)
				Debug.Log("오류");
		}

		return instance;
	}

	

	public void BGMMute(bool isMute)
	{
		
	}

	public void BGMPlay()
	{

	}

	public void BGMStop()
	{

	}

}
