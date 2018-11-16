using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectUI : MonoBehaviour {

    public ScrollRect view;
    public List<GameObject> Skill_Prefab;

	// Use this for initialization
	void Start () {
        view.gameObject.SetActive(false);

        //view.content = Skill_Prefab[0];


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
