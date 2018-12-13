using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    [AddComponentMenu("UI/EnhancedScroll Rect", 37)]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    [SelectionBase]
    public class EnhancedScrollerRect : ScrollRect
    {
        Vector2 BeginDragPos; //처음 누른자표

        public float fRectSize = 110f;//사각형 크기

        public bool bSelect = false;//선택

        //float fStartTime = 0f;//선택시간에 따라

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);

            BeginDragPos = eventData.position;

            //fStartTime = Time.time;

            Debug.Log("OnBeginDrag x = " + eventData.position.x + " y = " + eventData.position.y);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);

            //if (fStartTime + 0.1f < Time.time)
            //    return;

            Debug.Log("OnEndDrag x = " + eventData.position.x + " y = " + eventData.position.y);

            float fValue = (eventData.position.y - BeginDragPos.y);

            if (fValue > -fRectSize && fValue < fRectSize)//이건 선택유무고
            {
                bSelect = true;

                //누가 선택된건지는 어찌 알 수 있을까? 
            }
            else
                bSelect = false;

            Debug.Log("OnEndDrag bSelect = " + bSelect);
        }
    }
}