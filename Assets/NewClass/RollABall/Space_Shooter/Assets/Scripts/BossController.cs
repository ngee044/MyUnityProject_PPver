using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public BoltPool BossBoltPool;
    bool IsBossPhase;
    int bossBoltID;

	// Use this for initialization
	void Start () {
        IsBossPhase = false;
        bossBoltID = 0;    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
