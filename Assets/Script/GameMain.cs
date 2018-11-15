using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string Name = "유니티쨩";

        CharacterMgr.GetInstance.CreatePlayer(Name, 0);

        Debug.Log("플레이어 캐릭터 생성 완료");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
