using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour {

    public NavMeshAgent nav;
    public GameObject Target = null;
    public GameObject Path;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        Path = GameObject.Find("Path");
        Path = Path.transform.Find("Start").gameObject;
        
        StartCoroutine(Move());
	}
	
    IEnumerator Move()
    {
        while(true)
        {
            if(Target != null)
            {
                nav.SetDestination(Target.transform.position);
            }
            else
            {
                nav.SetDestination(Path.transform.position);
                if((transform.position - Path.transform.position).magnitude < 1.0f)
                {
                    if(Path.name == "Start")
                    {
                        Path = Path.transform.parent.Find("0").gameObject;
                    }
                    else
                    {
                        int node = int.Parse(Path.name);
                        node = node + 1;
                        GameObject Temp = Path.transform.parent.Find(node.ToString()).gameObject;
                        if(Temp != null)
                        {
                            Path = Temp;
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
