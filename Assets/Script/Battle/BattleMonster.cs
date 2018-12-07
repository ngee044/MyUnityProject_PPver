using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonster : MonoBehaviour {
    Monster m_Monster;
    public MonsterType SelectType;
    
    // Use this for initialization
    void Start() {
        m_Monster = CharacterMgr.GetInstance.GetMonster[(int)SelectType];

    }

    private void OnCollisionEnter(Collision rect)
    {
        if(rect.collider.tag == "bullet")
        {
            m_Monster.HP -= CharacterMgr.GetInstance.GetPlayer.ATK + 30;

            Destroy(rect.gameObject);

            if (m_Monster.HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision rect)
    {

    }

    private void OnCollisionExit(Collision rect)
    {
        //Player 쫒아가는 AI
    }

    // Update is called once per frame
    void Update () {
		
	}
}
