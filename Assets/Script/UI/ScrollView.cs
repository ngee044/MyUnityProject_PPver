using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewItemObject : MonoBehaviour
{
    public Button button;
    public Text Name;
    public Text Info;
    public Image Face;
    public GameObject confirm;


}

public class ScrollView : MonoBehaviour {

    public ScrollRect view;
    public List<GameObject> Skill_Prefab = new List<GameObject>();

    bool Is_ThisUI = false;


    // Use this for initialization
    void Start () {
        RenderPrefab();
        view.gameObject.SetActive(Is_ThisUI);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Is_ThisUI = !Is_ThisUI;
            view.gameObject.SetActive(Is_ThisUI);
        }
	}

    void RenderPrefab()
    {
        for (int i = 0; i < Skill_Prefab.Count; i++)
        {
            var inst = Instantiate(Skill_Prefab[i]);
            inst.transform.SetParent(view.content);
        }
    }
}
