using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTextureScroller : MonoBehaviour {

    // Scroll main texture based on time

    public float scrollSpeed = -0.25f;
    Renderer rend;
    Material mat;

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        mat.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(true);
    }
}
