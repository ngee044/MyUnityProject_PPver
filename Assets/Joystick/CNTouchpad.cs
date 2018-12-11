using UnityEngine;

/// <summary>
/// Touchpad control. Much like in Dead Trigger 2 or Shadowgun
/// </summary>
public class CNTouchpad : CNAbstractController
{
    // -------------------------
    // Editor visible properties
    // -------------------------
    /// <summary>
    /// Set to true if you wan't to fully control the speed of the drag
    /// It will feel more responsive if set to FALSE
    /// </summary>
    public bool IsAlwaysNormalized { get { return _isAlwaysNormalized; } set { _isAlwaysNormalized = value; } }

    // Serialized fields
    [SerializeField]
    [HideInInspector]
    private bool _isAlwaysNormalized = true;

    /// <summary>
    /// To find touch movement delta we need to store previous touch position
    /// It's stored in world coordinates to provide resolution invariance
    /// since different mobile devices have different DPI
    /// </summary>
    public Vector3 PreviousPosition { get; set; }

    /// <summary>
    /// Good old Update method where all the magic happens
    /// </summary>
    protected virtual void Update()
    {
        // If we tweaked, we return and don't check for other touches

        if (m_IsTouch == false)
            return;

        TweakControl( m_TouchPos );

        // Setting our initial "previous" position
        PreviousPosition = m_TouchPos;
    }

    /// <summary>
    /// Automatically called by TweakIfNeeded
    /// </summary>
    /// <param name="touchPosition">Touch position in screen pixels</param>
    protected override void TweakControl(Vector2 touchPosition)
    {
        //Vector3 worldPosition = touchPosition;

        //Vector3 difference = worldPosition - PreviousPosition;

        //if (IsAlwaysNormalized)
        //    difference.Normalize();

        //CurrentAxisValues = difference;
        //PreviousPosition = worldPosition;
    }
}
