using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeAmount;

    void OnEnable()
    {
        StartCoroutine(timeOut());
    }

    IEnumerator timeOut()
    {
        yield return new WaitForSeconds(TimeAmount);
        gameObject.SetActive(false);
    }
}
