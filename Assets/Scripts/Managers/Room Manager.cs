using System.Collections;

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the selection, opening, and closing of stages in the game.
/// 
/// Author: William Min
/// Date: 12/22/25
/// </summary>
public class RoomManager: MonoBehaviour
{
    #region Serialized Fields


    [SerializeField] private RectTransform _roomStorage;    // Transform that contains all the stages
    [SerializeField] private int _currentRoomIndex;         // Index of the currently opened stage

    [Space]
    [SerializeField] private AnimationPlayer _player;   // Reference to animation player playing the stage transition animations
    [SerializeField] private int _fadeInIndex;          // Index of animation in animation player for fade-in transition
    [SerializeField] private int _fadeOutIndex;         // Index of animation in animation player for fade-out transition
    [Space] 
    
    /// <summary>
    /// Events for when switching stages.
    /// </summary>
    public UnityEvent<int> OnSwitchToRoom;


    #endregion

    #region Private Fields


    private Vector2[] _roomSizeDeltas;  // Stage dimensions for setting them up for scrolling


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
    /// Loads the stage on the given index.
    /// </summary>
    /// <param name="index">Index of stage to be loaded</param>
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
    /// Loads the next or previous stage based on the number of steps.
    /// Positive values represent next stages, and negative values represent previous stages.
    /// </summary>
    /// <param name="indexStep">Number of steps of index for the next stage</param>
    public void LoadNextRoom(int indexStep)
    {
        LoadRoom(_getNextIndex(indexStep));
    }

    /// <summary>
    /// Loads the stage on the given index with a transition animation.
    /// </summary>
    /// <param name="index">Index of stage to be loaded</param>
    public void TransitionToRoom(int index)
    {
        StartCoroutine(_transitionToRoom(index));
    }

    /// <summary>
    /// Loads the next or previous stage based on the number of steps with a transition animation.
    /// Positive values represent next stages, and negative values represent previous stages.
    /// </summary>
    /// <param name="indexStep">Number of steps of index for the next stage</param>
    public void TransitionToNextRoom(int indexStep)
    {
        TransitionToRoom(_getNextIndex(indexStep));
    }


    #endregion

    #region Private Methods


    // Enacts the transition animation for transitioning between stages
    private IEnumerator _transitionToRoom(int index)
    {
        _player.Play(_fadeInIndex);

        yield return new WaitForSeconds(.15f);
        yield return new WaitUntil(() => !_player.IsPlaying());

        LoadRoom(index);
        OnSwitchToRoom?.Invoke(_currentRoomIndex);

        _player.Play(_fadeOutIndex);
    }

    // Returns the next valid index based on the given "next steps" value
    private int _getNextIndex(int indexSteps)
    {
        int nextIndex = indexSteps + _currentRoomIndex;

        if (nextIndex < 0)
        {
            nextIndex = nextIndex % _roomStorage.childCount + _roomStorage.childCount;
        }
        else if (nextIndex >= _roomStorage.childCount)
        {
            nextIndex = nextIndex % _roomStorage.childCount;
        }

        return nextIndex;
    }


    #endregion
}
