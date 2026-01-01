using UnityEngine;
using UnityEngine.UI;

using Intersection;

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 12/22/25
/// </summary>
public class ScrollRoom : MonoBehaviour
{
    #region Serialized Fields


    [Range(-1f, 1f)] [SerializeField] private float _scrollSpeed;   // 

    [Header("Scroll Room References")]
    [SerializeField] private Scrollbar _scroller;                   // 
    [SerializeField] private RectTransform _roomContainer;          // 
    [SerializeField] private Image _leftScrollerBox;                // 
    [SerializeField] private Image _rightScrollerBox;               // 


    #endregion

    #region Constants


    private float SPEED_CONVERSION = 2000;  // 


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
        else if (_scroller.value >= _scroller.size)
        {
            _scroller.value = _scroller.size;
            _rightScrollerBox.raycastTarget = false;
        }
    }


    #endregion

    #region Public Methods


    /// <summary>
    /// 
    /// </summary>
    /// <param name="newSpeed"></param>
    public void SetScrollSpeed(float newSpeed)
    {
        _scrollSpeed = newSpeed;
    }


    #endregion
}
