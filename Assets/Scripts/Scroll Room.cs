using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 12/22/25
/// </summary>
public class ScrollRoom : MonoBehaviour
{
    #region Serialized Fields


    [SerializeField] private Scrollbar _scroller;                   // 
    [Range(-1f, 1f)] [SerializeField] private float _scrollSpeed;   // 


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
        _scroller.value += _scrollSpeed * Time.deltaTime;
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
