using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour {

    protected struct Status
    {
        public string Name;
        public int hp;
        public int mp;
        public int atk;
        public int def;
    }

    public List<Animator> ListAnimator = new List<Animator>();

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {



	}
}
