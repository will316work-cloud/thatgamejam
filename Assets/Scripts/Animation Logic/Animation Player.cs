using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 
/// 
/// Author: WIlliam Min
/// Date: 12/24/25
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    #region Serialized Fields


    [SerializeField] private AnimationParameters[] _parameters;     // 
    [Space] [SerializeField] private UnityEvent[] _animationEvents; // 


    #endregion

    #region Private Fields


    private Animator _animationController;  // 


    #endregion

    #region MonoBehavior Callbacks


    private void Awake()
    {
        _animationController = GetComponent<Animator>();
    }


    #endregion

    #region Public Methods


    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void Play(int index)
    {
        _parameters[index].Play(_animationController);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void CrossFade(int index)
    {
        _parameters[index].Crossfade(_animationController);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Stop()
    {
        _animationController.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool IsPlayingAnimation(int index)
    {
        return _parameters[0].IsPlayingState(_animationController);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        foreach (AnimationParameters parameters in _parameters)
        {
            if (parameters.IsPlayingState(_animationController))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void PlayAnimationEvent(int index)
    {
        _animationEvents[index]?.Invoke();
    }


    #endregion
}

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 12/24/25
/// </summary>
[System.Serializable]
public class AnimationParameters
{
    #region Serialized Fields


    [Header("General Animation Play Settings")]
    [SerializeField] private string _stateName;                     // 
    [SerializeField] private int _layer;                            // 
    [SerializeField] private float _normalizedTimeOffset = 0.0f;    // 

    [Header("Crossfade Settings")]
    [SerializeField] private float _normalizedTransitionDuration;       // 
    [SerializeField] private float _normalizedTransitionTime = 0.0f;    // 


    #endregion

    #region Public Methods


    /// <summary>
    /// 
    /// </summary>
    /// <param name="animator"></param>
    public void Play(Animator animator)
    {
        animator.Play(_stateName, _layer, _normalizedTimeOffset);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="animator"></param>
    public void Crossfade(Animator animator)
    {
        animator.CrossFade(_stateName, _normalizedTransitionDuration, _layer, _normalizedTimeOffset, _normalizedTransitionTime);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="animator"></param>
    /// <returns></returns>
    public bool IsPlayingState(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(_layer);
        float normailzedTime = stateInfo.normalizedTime;
        bool matchingName = stateInfo.IsName(_stateName);

        //Debug.Log(normailzedTime);
        //Debug.Log(matchingName);

        return matchingName && normailzedTime < 1.0f;
    }


    #endregion
}
