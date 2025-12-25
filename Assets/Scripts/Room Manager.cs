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


    [SerializeField] private Transform _roomStorage;    // 
    [SerializeField] private int _currentRoomIndex;     // 

    [Space]
    [SerializeField] private AnimationPlayer _player;   // 
    [SerializeField] private int _fadeInIndex;          // 
    [SerializeField] private int _fadeOutIndex;         // 
    [Space] public UnityEvent<int> OnSwitchToRoom;      // 


    #endregion

    #region MonoBehavior Callbacks


    protected void Awake()
    {
        for (int i = 0; i < _roomStorage.childCount; i++)
        {
            _roomStorage.GetChild(i).gameObject.SetActive(false);
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
        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(false);

        _currentRoomIndex = index;

        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(true);
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
