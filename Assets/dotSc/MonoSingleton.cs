using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
//{​
//    private static T instance = null;
//    public static T Instance
//    {
//        get
//        {
//            if(!instance)
//            {
//                GameObject obj;
//                obj = GameObject.Find(typeof(T).Name);
//                if(!obj)
//                {
//                    obj = new GameObject(typeof(T).Name);
//                    instance = obj.AddComponent<T>();
//                }
//                else
//                {
//                    instance = obj.GetComponent<T>();
//                }
//            }
//            return instance;
//        }

//    }

//    public void Awake()
//    {
//        DontDestroyOnLoad(gameObject);
//    }
//}
