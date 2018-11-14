using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour {

    public Slider HP;
    private float MyHp = 1;

    

	// Use this for initialization
	void Start () {
        HP.value = MyHp;
        StartCoroutine(HPEvent());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator HPEvent()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            HP.value -= 0.01f;

            if(HP.value <= 0)
            {
                HP.value = 0;
                break;
            }
        }
    }

    

}
