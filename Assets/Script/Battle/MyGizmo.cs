using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour {

    public Color myColor = Color.yellow;
    public float Radius = 0.1f; // 반지름

    private void OnDrawGizmos()
    {
        Gizmos.color = myColor;
        Gizmos.DrawSphere(transform.position, Radius); //위치, 반지름
    }
}
