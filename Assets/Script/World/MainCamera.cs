using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainCamera : MonoBehaviour {

    public class cShakeInfo
    {
        public float m_StartDelay;

        public bool m_UseTotalTime;
        public float m_TotalTime;

        public Vector3 m_Dest;
        public Vector3 m_Shake;
        public Vector3 m_Dir;

        public float m_RemainDist;
        public float m_RemainCountDist;

        public bool m_UseCount;
        public int m_Count;

        public float m_Veciocity;
        public bool m_UseDamping;
        public float m_Damping;
        public float m_DampingTime;
    }
        public bool m_bCameraShake = false;
        Transform m_ShakeTr;
        Vector3 m_vOrgPosZone = new Vector3(0, 0, 0);
        Vector3 m_OldPlayerPos = new Vector3(0, 0, 0);  

        protected void initShake()
        {
            m_ShakeTr = transform.parent;
            m_bCameraShake = false;
        }

        protected void ResetShakeTr()
        {
            m_ShakeTr.localPosition = Vector3.zero;
            m_bCameraShake = false;

            CameraLimit();
        }
    
        cShakeInfo m_ShakeInfo = new cShakeInfo();

        public void Shake()
        {
            m_ShakeInfo.m_StartDelay = 0;// info.m_fStarDelay;

            m_ShakeInfo.m_TotalTime = 0.6f;//into.m_fTime;
            m_ShakeInfo.m_UseTotalTime = m_ShakeInfo.m_TotalTime > 0f;

            m_ShakeInfo.m_Shake = new Vector3(1 /*into.m_fShake_X*/, /*info.m_fShke_Y*/ 0.2f, 0);

            //if (bOwnerFront == false)
            //    m_ShakeInfo.m_Shake.x = -m_ShakeInfo.m_Shake.x;

            m_ShakeInfo.m_Dest = m_ShakeInfo.m_Shake;

            m_ShakeInfo.m_Dir = m_ShakeInfo.m_Shake;
            m_ShakeInfo.m_Dir.Normalize();

            m_ShakeInfo.m_RemainDist = m_ShakeInfo.m_Shake.magnitude;
            m_ShakeInfo.m_RemainCountDist = float.MaxValue;

            m_ShakeInfo.m_Veciocity = 20;//info.m_fSpeed;

            m_ShakeInfo.m_Damping = 1;//info.m_fDamping;
            m_ShakeInfo.m_UseDamping = m_ShakeInfo.m_Damping > 0f;

            if (m_ShakeInfo.m_UseDamping)
            {
                m_ShakeInfo.m_DampingTime = m_ShakeInfo.m_RemainDist / m_ShakeInfo.m_Veciocity;
            }

            m_ShakeInfo.m_Count = 4;//info.m_nShakeCount;
            m_ShakeInfo.m_UseCount = (m_ShakeInfo.m_Count > 0);

            StopCoroutine("ShakeCoroutine");
            ResetShakeTr();
            StartCoroutine("ShakeCoroutine");

        }


        void CameraLimit(bool bOrgPosY = false)
        {
            Vector3 camerapos = m_vOrgPosZone;
            /*
            Vector3 v1 = ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 v2 = ViewportToWorldPoint(new Vector3(1, 1, 0));
            */

            switch (0)
            {
                case 0://eMOVE_TYPE.FOLLOW:
                    camerapos.x = m_OldPlayerPos.x;
                    camerapos.y = 0.1f; // 카메라만 흔들면 맵이 안됨  맵과 카메라를 다 흔들어야 비어있는 곳이 안보인다
                        //transform.parent.position.y
                        //+ m_vOrgPosZone.y
                        //+ ((m_OldPlayerPos.y - m_OrgPosZone.y)
                        //- m_PlayerCameraOffsetY) * m_ChangeYRate;
                    break;

                //case eMOVE_TYPE.FREEZE_X:
                //    camerapos.y =
                //        transform.parent.position.y
                //        + m_vOrgPosZone.y
                //        + ((m_OldPlayerPos.y - m_vOrgPosZone.y)
                //        - m_PlayerCameraOffsetY) * m_ChangeYRate;
                //    break;
                //case eMOVE_TYPE.XY:
                //  break;
                default:
                    break;
            }

            if (camerapos.x - 0.1f < 0.1f) // m_CameraFOV_X CurZone.left
            {
                camerapos.x = 0.1f + 0.1f; // m_CameraFOV_X CurZone.left
            }
            else if (camerapos.x + 0.1f > 0.1f)// m_CameraFOV_X CurZone.right
            {
                camerapos.x = 0.1f + 0.1f; // m_CameraFOV_X CurZone.left
            }

            if (bOrgPosY)
                camerapos.y = m_vOrgPosZone.y;
        }

        IEnumerator ShakeCoroutine()
        {
            m_bCameraShake = true;
            float dt;
            float dist;

            if (m_ShakeInfo.m_StartDelay > 0)
            {
                yield return new WaitForSeconds(m_ShakeInfo.m_StartDelay);
            }

            while (true)
            {
                dt = Time.fixedDeltaTime;
                dist = dt * m_ShakeInfo.m_Veciocity;

                if ((m_ShakeInfo.m_RemainDist -= dist) > 0)
                {
                    m_ShakeTr.localPosition += m_ShakeInfo.m_Dir * dist;

                    float rc = transform.position.x - 0.1f/* 카메라 좌표*/ - 0.1f;

                    if (rc < 0)
                    {
                        m_ShakeTr.localPosition += new Vector3(-rc, 0, 0);
                    }

                    rc = 0.1f/* 카메라 좌표*/ - (transform.position.x + 0.1f);

                    if (rc < 0)
                    {
                        m_ShakeTr.localPosition += new Vector3(rc, 0, 0);
                    }

                    CameraLimit(true);

                    if (m_ShakeInfo.m_UseCount)
                    {
                        m_ShakeInfo.m_RemainCountDist = float.MaxValue;

                        if (--m_ShakeInfo.m_Count <= 0)
                            break;
                    }

                }
                else
                {
                    if (m_ShakeInfo.m_UseDamping)
                    {
                        float distDamping = Mathf.Max(
                            m_ShakeInfo.m_DampingTime * m_ShakeInfo.m_DampingTime, m_ShakeInfo.m_DampingTime * dt);

                        if (m_ShakeInfo.m_Shake.magnitude > distDamping)
                        {
                            m_ShakeInfo.m_Shake -= m_ShakeInfo.m_Dir * distDamping;
                        }
                        else
                        {
                            m_ShakeInfo.m_UseCount = true;
                            m_ShakeInfo.m_Count = 1;
                        }
                    }

                    m_ShakeTr.localPosition =
                        m_ShakeInfo.m_Dest - m_ShakeInfo.m_Dir * (-m_ShakeInfo.m_RemainDist);

                    float rc = transform.position.x - 0.1f - 0.1f; //카메라 좌표, CurZone.left

                    if (rc < 0)
                    {
                        m_ShakeTr.localPosition += new Vector3(-rc, 0, 0);
                    }

                    rc = 0.1f - 0.1f; /*(CurZone.Right - transform.position.x + m_CameraFOV_X);*/

                    if (rc < 0)
                    {
                        m_ShakeTr.localPosition += new Vector3(rc, 0, 0);

                        CameraLimit(true);

                        m_ShakeInfo.m_Shake = -m_ShakeInfo.m_Shake;
                        m_ShakeInfo.m_Dest = m_ShakeInfo.m_Shake;
                        m_ShakeInfo.m_Dir = -m_ShakeInfo.m_Dir;

                        float len = m_ShakeInfo.m_Shake.magnitude;

                        m_ShakeInfo.m_RemainCountDist = len + m_ShakeInfo.m_RemainDist;
                        m_ShakeInfo.m_RemainDist += len * 2f;

                        m_ShakeInfo.m_DampingTime = m_ShakeInfo.m_RemainDist / m_ShakeInfo.m_Veciocity;

                        if (m_ShakeInfo.m_RemainDist < dist)
                        {
                            break;
                        }
                    }

                    if (m_ShakeInfo.m_UseTotalTime && ((m_ShakeInfo.m_TotalTime -= dt) < 0))
                        break;
                }

            }




        }

}



