//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System.Threading;

//public class ThreadLauncher : MonoBehaviour {

//    public Slider bar; // down
//    public Slider bar2; // unzip

//    private Thread m_DownLoadThread = null;
//    private Thread m_UnZipThread = null;

//    Object sync = new Object();

//    float nCount = 0;
//    float nCount2 = 0;

//    public float Count
//    {
//        get
//        {
//            lock (sync)
//            {
//                return nCount;
//            }
//        }
//    }

//    public float Count2
//    {
//        get
//        {
//            lock (sync)
//            {
//                return nCount2;
//            }
//        }
//    }
//    void Awake()
//    {

//    }

//    void Start()
//    {
//        bar.value = 0;
//        bar2.value = 0;

//        m_DownLoadThread = new Thread(DownLoadThread);
//        m_DownLoadThread.Start();

//        m_UnZipThread = new Thread(UnZipThread);
//        m_UnZipThread.Start();
//    }

//    void Update()
//    {
//        if(nCount >= 1)
//        {
//            nCount = 0;
//        }
//        if (nCount2 >= 1)
//        {
//            nCount2 = 0;
//        }
//        bar.value = nCount;
//        bar2.value = nCount2;
//    }

//    public void DownLoadThread()
//    {
//        if (true)
//        {

//            Thread.Sleep(1);
//            lock (sync)
//            {
//                Debug.Log("2222222222222222222");
//                nCount += 0.05f;
//            }

//        }
//    }

//    public void UnZipThread()
//    {
//        if (true)
//        {
//            Thread.Sleep(1);
//            lock (sync)
//            {
//                Debug.Log("11111111111111111");
//                nCount2 += 0.05f;
//            }
//        }
//    }
//}
