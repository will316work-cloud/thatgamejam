using UnityEngine;
using UnityEngine.UI;

public class ScrollRoom : MonoBehaviour
{
    [SerializeField] private Scrollbar _scroller;
    [Range(-1f, 1f)] [SerializeField] private float _scrollSpeed;

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

    public void SetScrollSpeed(float newSpeed)
    {
        _scrollSpeed = newSpeed;
    }
}
