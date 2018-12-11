using UnityEngine;



// Common Joystick control
// There're lots of these, you know
[ExecuteInEditMode]
public class CNJoystick : CNAbstractController
{
    // ---------------------------------
    // Editor visible public properties
    // ---------------------------------
    /// <summary>
    /// Drag radius is a maximum distance on which you can drag the stick relative to the center of the base
    /// </summary>
    [HideInInspector]
    public float DragRadius { get { return _dragRadius; } set { _dragRadius = value; } }
    /// <summary>
    /// Indicates whether the joystick should "Snap" to the finger, placing itself on the touch position
    /// </summary>
    [HideInInspector]
    public bool SnapsToFinger { get { return _snapsToFinger; } set { _snapsToFinger = value; } }
    /// <summary>
    /// Indicates whether it should disappear when it's not being tweaked
    /// </summary>
    [HideInInspector]
    public bool IsHiddenIfNotTweaking { get { return _isHiddenIfNotTweaking; } set { _isHiddenIfNotTweaking = value; } }

    // Serialized fields (user preferences)
    // We also hide them in the inspector so it's not shown automatically
    [SerializeField]
    [HideInInspector]
    private float _dragRadius = 1.5f;

    [SerializeField]
    [HideInInspector]
    private bool _snapsToFinger = true;

    [SerializeField]
    [HideInInspector]
    private bool _isHiddenIfNotTweaking;

    void Awake()
    {
    }

    void Start()
    {   
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void PointerDown()
    {
        base.PointerDown();
    }

    protected override void PointerUp()
    {
        base.PointerUp();
    }

    /// <summary>
    /// In this method we also need to set the stick and base local transforms back to zero
    /// </summary>
    public override void ResetControlState()
    {
        base.ResetControlState(); 
    }

    protected virtual void Update()
    {
    }

    /// <summary>
    /// Function for joystick tweaking (moving with the finger)
    /// The values of the Axis are also calculated here
    /// </summary>
    /// <param name="touchPosition">Current touch position in screen cooridnates (pixels)
    /// It's recalculated in units so it's resolution-independent</param>
    protected override void TweakControl(Vector2 touchPosition)
    {
    }
}
