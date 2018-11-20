using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ThreadLauncher : MonoBehaviour
{

    public Slider bar; // down
    public Slider bar2; // unzip

    private Thread m_DownLoadThread = null;
    private Thread m_UnZipThread = null;

    Object sync = new Object();

    float nCount = 0;
    float nCount2 = 0;


    void Awake()
    {

    }

    void Start()
    {
        bar.value = 0;
        bar2.value = 0;

        m_DownLoadThread = new Thread(DownLoadThread);
        m_DownLoadThread.Start();

        m_UnZipThread = new Thread(UnZipThread);
        m_UnZipThread.Start();
    }

    void Update()
    {
        bar.value = nCount;
        bar2.value = nCount2;
    }

    public void DownLoadThread()
    {
        while (true)
        {
            if (nCount >= 1)
                nCount = 0;
            nCount += 0.05f;
            Thread.Sleep(150);
        }
    }

    public void UnZipThread()
    {
        while (true)
        {
            if (nCount2 >= 1)
                nCount2 = 0;

            nCount2 += 0.05f;
            Thread.Sleep(150);
        }
    }
}
