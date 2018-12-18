using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusing : MonoBehaviour {
    
    MainCamera m_MainCamera;
    public float m_ZoomDelta;
    
    public class cZoomInfo
    {
        public float m_StartDelay;
        public bool m_IsZoom;
        public float m_Dest;
        public float m_FadeIn_Velocity;
        public float m_Duration;
        public float m_FadeOut_Velocity;

        public float m_FadeIn_Time; //Zoom in Effect
        public float m_FadeOut_Time;    //Camera Zoom Defalut
        public float m_FadeIn_MoveSpeed;
        public float m_FadeOut_MoveSpeed;

        public Vector3 m_DeltaDir;
    }

    cZoomInfo m_Zoominfo = new cZoomInfo();
    bool m_IsEndStage = false;
    bool m_IsFallowMy = false;
    protected void ResetZoom()
    {
        m_IsEndStage = true;
    }

    public void ZoomEndStage(float StartDelay, float ZoomDest, float BlendlnTime, float Duration, float BlendOutTime, Vector3 vDeltaPos)
    {
        m_IsEndStage = true;

        m_Zoominfo.m_FadeIn_Time = BlendlnTime * Time.timeScale;
        m_Zoominfo.m_FadeOut_Time = BlendOutTime * Time.timeScale;

        m_Zoominfo.m_StartDelay = StartDelay;
        m_Zoominfo.m_Dest = ZoomDest;
        m_Zoominfo.m_IsZoom = m_Zoominfo.m_Dest < 0;
        m_Zoominfo.m_Duration = Duration * Time.timeScale;
        m_Zoominfo.m_FadeIn_Velocity = m_Zoominfo.m_Dest / m_Zoominfo.m_FadeIn_Time;
        m_Zoominfo.m_FadeOut_Velocity = -m_Zoominfo.m_Dest / m_Zoominfo.m_FadeOut_Time;

        if(vDeltaPos != Vector3.zero)
        {
            vDeltaPos.z = 0;
            float lenth = vDeltaPos.magnitude;
            m_Zoominfo.m_FadeIn_MoveSpeed = lenth / m_Zoominfo.m_FadeIn_Time;
            m_Zoominfo.m_FadeOut_MoveSpeed = lenth / m_Zoominfo.m_FadeOut_Time;
            vDeltaPos.Normalize();

            StopCoroutine("ShakeCoroutine");
        }

        m_Zoominfo.m_DeltaDir = vDeltaPos;
        ResetZoom();
        StartCoroutine("ZoomEndStageCoroutine");
    }

    IEnumerator ZoomEndStageCoroutine()
    {
        //CameraFilterPack_Blur_Focus filter = m_camera.gameObject.AddComponent<CameraFilterPack_Blur_Focus>();
        CameraFilterPack_Blur_Focus filter = this.gameObject.AddComponent<CameraFilterPack_Blur_Focus>();
        CameraFilterPack_Blur_Focus.ChangeEyes = 20.0f;

        float dt, delta;

        if(m_Zoominfo.m_StartDelay > 0)
        {
            yield return new WaitForSeconds(m_Zoominfo.m_StartDelay);
        }

        Transform trCon = transform.parent.parent;
        bool bMoveCamera = false;

        if(m_Zoominfo.m_DeltaDir != Vector3.zero)
        {
            bMoveCamera = true;
            m_IsFallowMy = false;
        }

        while(true)
        {
            dt = Time.deltaTime;
            delta = dt * m_Zoominfo.m_FadeIn_Velocity;

            if(CameraFilterPack_Blur_Focus.ChangeEyes > 3.0f) // change allow value
            {
                CameraFilterPack_Blur_Focus.ChangeEyes -= (17f * dt) / m_Zoominfo.m_FadeIn_Time;

                if (CameraFilterPack_Blur_Focus.ChangeEyes < 3.0f)
                    CameraFilterPack_Blur_Focus.ChangeEyes = 3.0f;
            }

            if(bMoveCamera)
            {
                if((m_Zoominfo.m_FadeIn_Time -= dt) > 0f)
                {
                    trCon.position += m_Zoominfo.m_DeltaDir * dt * m_Zoominfo.m_FadeOut_MoveSpeed;
                }
                else
                {
                    trCon.position +=
                        m_Zoominfo.m_DeltaDir * (m_Zoominfo.m_FadeIn_Time + dt)
                        * m_Zoominfo.m_FadeIn_MoveSpeed;

                    bMoveCamera = false;
                }
            }

            if(m_Zoominfo.m_IsZoom)
            {
                if((m_ZoomDelta + delta) < m_Zoominfo.m_Dest)
                {
                    m_ZoomDelta = m_Zoominfo.m_Dest;
                    break;
                }
                m_ZoomDelta += delta;
            }
            else
            {
                if((m_ZoomDelta + delta) > m_Zoominfo.m_Dest)
                {
                    m_ZoomDelta = m_Zoominfo.m_Dest;
                    break;
                }
                m_ZoomDelta += delta;
            }

            yield return null;
        }

        if(m_Zoominfo.m_DeltaDir != Vector3.zero)
        {
            bMoveCamera = true;
        }

        while(true)
        {
            dt = Time.deltaTime;
            delta = dt * m_Zoominfo.m_FadeOut_Velocity;

            if(CameraFilterPack_Blur_Focus.ChangeEyes < 3.0f) //change allow value
            {
                CameraFilterPack_Blur_Focus.ChangeEyes += (17f * dt) / m_Zoominfo.m_FadeOut_Time;
            }

            if(bMoveCamera == true)
            {
                if((m_Zoominfo.m_FadeOut_Time -= dt)>0f)
                {
                    trCon.position -= m_Zoominfo.m_DeltaDir * dt * m_Zoominfo.m_FadeOut_MoveSpeed;
                }
                else
                {
                    trCon.position -=
                        m_Zoominfo.m_DeltaDir *
                        (m_Zoominfo.m_FadeOut_Time + dt) *
                        m_Zoominfo.m_FadeOut_MoveSpeed;

                    bMoveCamera = false;
                }
            }

            if(m_Zoominfo.m_IsZoom)
            {
                if((m_ZoomDelta + delta) >0)
                {
                    m_ZoomDelta = 0f;
                    break;
                }
                m_ZoomDelta += delta;
            }
            else
            {
                if ((m_ZoomDelta + delta) > 0)
                {
                    m_ZoomDelta = 0f;
                    break;
                }
                m_ZoomDelta += delta;
            }

            yield return null;
        }
        Destroy(filter);
    }

    public void Zoom(int CameraID)
    {
        //  ZoomndStage(0.1f, -0.2f, 0.2f, 0.2f, Vector3.zero);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z))
        {
    //        camera.Zoom(0);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            //shake
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {

        }
	}

    


}
