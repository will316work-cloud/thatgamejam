using System.Collections;

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 12/22/25
/// </summary>
public class RoomManager: MonoBehaviour
{
    #region Serialized Fields


    [SerializeField] private RectTransform _roomStorage;    // 
    [SerializeField] private int _currentRoomIndex;     // 

    [Space]
    [SerializeField] private AnimationPlayer _player;   // 
    [SerializeField] private int _fadeInIndex;          // 
    [SerializeField] private int _fadeOutIndex;         // 
    [Space] public UnityEvent<int> OnSwitchToRoom;      // 


    #endregion

    #region Private Fields


    private Vector2[] _roomSizeDeltas;


    #endregion

    #region MonoBehavior Callbacks


    protected void Awake()
    {
        _roomSizeDeltas = new Vector2[_roomStorage.childCount];

        for (int i = 0; i < _roomStorage.childCount; i++)
        {
            _roomStorage.GetChild(i).gameObject.SetActive(false);
            _roomSizeDeltas[i] = _roomStorage.GetChild(i).GetComponent<RectTransform>().sizeDelta;
        }

        LoadRoom(_currentRoomIndex);
    }


    #endregion

    #region Public Methods


    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void LoadRoom(int index)
    {
        //Debug.Log(_roomStorage.GetComponent<RectTransform>().sizeDelta);

        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(false);
        //Debug.Log(_roomStorage.GetChild(_currentRoomIndex).GetComponent<RectTransform>().sizeDelta);

        _currentRoomIndex = index;

        _roomStorage.sizeDelta = _roomSizeDeltas[_currentRoomIndex];
        _roomStorage.GetChild(_currentRoomIndex).GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(true);
        //Debug.Log(_roomStorage.GetChild(_currentRoomIndex).GetComponent<RectTransform>().sizeDelta);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void TransitionToRoom(int index)
    {
        StartCoroutine(_transitionToRoom(index));
    }

    private IEnumerator _transitionToRoom(int index)
    {
        _player.Play(_fadeInIndex);

        yield return new WaitForSeconds(.15f);
        yield return new WaitUntil(() => !_player.IsPlaying());

        LoadRoom(index);
        OnSwitchToRoom?.Invoke(_currentRoomIndex);

        _player.Play(_fadeOutIndex);
    }


    #endregion
}
