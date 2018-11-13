using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MyPracticeSc : MonoBehaviour
{

    public List<Animator> ListAnimator = new List<Animator>();
    public Text label;
    bool m_bActive;
    float m_fStart;
    float m_fEnd;

    void Awake()
    {
        label = GetComponent<Text>();
    }

    void Start()
    {
        m_fStart = Time.time;
        m_fEnd = 1f;
    }

    void Update()
    {
        if(m_fStart + m_fEnd < Time.time)
        {
            //m_fEnd 값 초마다 이곳에 들어온다.
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_bActive = !m_bActive;
            label.transform.gameObject.SetActive(m_bActive);

        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            label.text = "Change text";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Animator ani in ListAnimator)
                ani.SetTrigger("RUNTrigger");
        }
    }

    void FixedUpdate()
    {

    }

    public void AttackEvent()
    {
        Debug.Log("Attack Event");
    }

    public void RunEvent()
    {
        Debug.Log("RUN EVENT");
    }

}

