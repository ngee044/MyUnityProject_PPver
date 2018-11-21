using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading;

public class UnZipQueue
{
    public string strPath;

}

public class MyPracticeSc : MonoBehaviour
{

    public List<Animator> ListAnimator = new List<Animator>();
    public Text label;
    bool m_bActive;
    float m_fStart;
    float m_fEnd;
    string m_local;
    string m_root;
    string m_Exception = "";

    Queue<UnZipQueue> m_UnZipQueue = new Queue<UnZipQueue>();
    long m_ZipSize;
    UnZipQueue myzip = new UnZipQueue();
    void Awake()
    {
        label = GetComponent<Text>();

    }

    void Start()
    {
        m_fStart = Time.time;
        m_fEnd = 1f;

        myzip.strPath = "C:\\test.zip";
        m_UnZipQueue.Enqueue(myzip);
        UnZipQueue unzip = m_UnZipQueue.Dequeue();
        m_ZipSize = Zip.GetDeCompressFileSize(unzip.strPath);
        Debug.Log("Size = " + m_ZipSize);

        bool bRes = Zip.DeCompression(unzip.strPath, string.Format("{0}/AssetBundles/{1}/", m_local, m_root), ref m_Exception);
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

