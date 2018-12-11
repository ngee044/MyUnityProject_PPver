using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
using System.Reflection;
#endif

/// <summary>
/// Abstract controller class
/// It has all the functionality needed to implement your own controls
/// It also has a lot of commentary so you won't get missed
/// 
/// Also chech the CNAbstractControllerInspector.cs class in the Editor folder, as it uses a custom inspector
/// </summary>
[Serializable]
public abstract class CNAbstractController : MonoBehaviour , IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    protected static bool g_Lock = false;
    static int g_LockLevel = 0;

    public Image bgImage;
    public Image joystickImage;

    private Vector3 inputVector;
    private Vector3 BallDefalutpostion;
    private void Start()
    {
        //inputVector = joystickImage.transform.position;
    }

    public static bool IsLock()
    {
        return g_Lock;
    }

    public static void Lock( int Level = 0 )
    {
        if( Level < g_LockLevel )
            return;

        g_Lock = true;
        g_LockLevel = Level;
    }
    public static void Unlock( int Level = 0 )
    {
        if( Level < g_LockLevel )
            return;

        g_Lock = false;
        g_LockLevel = 0;
    }

    protected bool m_IsTouch = false;
    protected Vector2 m_TouchPos;

    protected virtual void PointerDown()
    {
        
    }

    protected virtual void PointerUp()
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        //joystickImage.transform.position = BallDefalutpostion;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

        PointerDown();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        m_IsTouch = false;
        ResetControlState();

        PointerUp();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag joyStick <<");
        if (g_Lock == true)
            return;

        m_IsTouch = true;
        m_TouchPos = eventData.position;
        m_TouchPos.x *= (1024 / (float)Screen.width);
        m_TouchPos.y *= (768.0f / (float)Screen.height);

        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, m_TouchPos, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            Debug.Log("0: " + inputVector);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 3),
                                                                        inputVector.y * (bgImage.rectTransform.sizeDelta.y / 3));

            Debug.Log(pos);
            Debug.Log("1: "+inputVector);
            Debug.Log(joystickImage.rectTransform.anchoredPosition);
        }
    }

    protected RectTransform TransformCache { get; set; }
    //protected Vector2 CurrentAxisValues { get; set; }
    protected float CurrentAxis_X { get; set; }
    protected float CurrentAxis_Y { get; set; }

    public enum eAXIS
    {
        AXIS_X,
        AXIS_Y,
    }

    public virtual float GetAxis( eAXIS axis )
    {
        switch( axis )
        {
            case eAXIS.AXIS_X:
                return CurrentAxis_X;
            case eAXIS.AXIS_Y:
                return CurrentAxis_Y;
        }

        return 0;
    }

    void OnDisable()
    {
        Disable();
    }

    public virtual void Disable()
    {
        CurrentAxis_X = CurrentAxis_Y = 0;

        //gameObject.SetActive(false);
        // Unity defined MonoBehaviour property
        //enabled = false;
    }

    /// <summary>
    /// Call this method to enable the control back
    /// It will then respond to Unity callbacks
    /// </summary>
    public virtual void Enable()
    {
        //gameObject.SetActive(true);
        // Unity defined MonoBehaviour property
        //enabled = true;
    }

    /// <summary>
    /// Neat initialization method
    /// </summary>
    /// 
    Rect CalculatedTouchZone;
    public virtual void OnEnable()
    {
        TransformCache = GetComponent<RectTransform>();

        CalculatedTouchZone = new Rect(TransformCache.rect);
        CalculatedTouchZone.x += TransformCache.anchoredPosition.x;
        CalculatedTouchZone.y += TransformCache.anchoredPosition.y;
    }

    public virtual void ResetControlState()
    {
        CurrentAxis_X = CurrentAxis_Y = 0;
    }

    private bool IsTouchInZone(Vector2 touchPosition)
    {
        return CalculatedTouchZone.Contains(touchPosition, false);
    }

    protected abstract void TweakControl(Vector2 touchPosition);
}
