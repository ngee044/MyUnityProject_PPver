using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalPlace : MonoBehaviour {

    public string SceneName;

    private void OnCollisionStay(Collision rect)
    {
        if(rect.collider.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Move Scene : " + SceneName);
                LoadingUi.LoadScene(SceneName);
            }
        }
    }
}
