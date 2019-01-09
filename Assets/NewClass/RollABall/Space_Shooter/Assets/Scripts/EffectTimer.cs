using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {

    public float Timer;

    void OnEnable()
    {
        StartCoroutine(SleepAfter());
    }
    
    private IEnumerator SleepAfter()
    {
        yield return new WaitForSeconds(Timer);
        this.gameObject.SetActive(false);
    }
	
}
