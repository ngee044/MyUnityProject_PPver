using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalPlace : MonoBehaviour {

    public bool IsDungeon;
    public string SceneName;

    private void OnCollisionStay(Collision rect)
    {
        if(rect.collider.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Move Scene : " + SceneName);
                LoadingUi.LoadScene(SceneName);

                if(IsDungeon == true)
                {
                    CharacterMgr.GetInstance.GetMonster.Clear();
                    CharacterMgr.GetInstance.GetBoss = null;

                    if (SceneName == "Dungeon")
                    {
                        for (var i = MonsterType.eTYPE_MONSTER_ORCE; i < MonsterType.eTYPE_MONSTER_END; i++)
                            CharacterMgr.GetInstance.CreateMonster(i);
                    }
                }
                else
                {
                    CharacterMgr.GetInstance.GetMonster.Clear();
                    CharacterMgr.GetInstance.GetBoss = null;
                    Debug.Log("Nomal Map movement, Monster Index All Reset!!");
                }
            }
        }
    }
}
