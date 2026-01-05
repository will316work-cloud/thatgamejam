using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the scrolling of rooms and its interactions.
/// 
/// Author: William Min
/// Date: 12/22/25
/// </summary>
public class ScrollRoom : MonoBehaviour
{
    #region Serialized Fields


    [Range(-1f, 1f)] [SerializeField] private float _scrollSpeed;   // Current speed of scrolling the room

    [Header("Scroll Room References")]
    [SerializeField] private Scrollbar _scroller;                   // Scroll bar that handles the scrolling
    [SerializeField] private RectTransform _roomContainer;          // Transform that contains the stages of the game
    [SerializeField] private Image _leftScrollerBox;                // Image raycast target for left scroller box
    [SerializeField] private Image _rightScrollerBox;               // Image raycast target for right scroller box


    #endregion

    #region Constants


    private float SPEED_CONVERSION = 2000f;  // Conversion modifier of scroll speed


    #endregion

    #region MonoBehavior Callbacks


    private void Awake()
    {
        if (_scroller == null)
        {
            _scroller = GetComponent<Scrollbar>();
        }
    }

    private void FixedUpdate()
    {
        // Move scroller based on scroll speed
        _scroller.value += _scrollSpeed * SPEED_CONVERSION / _roomContainer.sizeDelta.x * Time.deltaTime;

        // Enable or disable image targets
        _leftScrollerBox.raycastTarget = true;
        _rightScrollerBox.raycastTarget = true;

        if (_scroller.value <= 0)
        {
            _scroller.value = 0;
            _leftScrollerBox.raycastTarget = false;
        }
        else if (_scroller.value >= 1)
        {
            _scroller.value = 1;
            _rightScrollerBox.raycastTarget = false;
        }
    }


    #endregion

    #region Public Methods


    /// <summary>
    /// Sets the speed to scroll along a window.
    /// </summary>
    /// <param name="newSpeed">New scroll speed</param>
    public void SetScrollSpeed(float newSpeed)
    {
        _scrollSpeed = newSpeed;
    }


    #endregion
}
