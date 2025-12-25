using UnityEngine;

using UnityEngine.Animations;

[CreateAssetMenu(fileName = "New Room Transition Animation", menuName = "Scriptables/Room Transition Animation")]
public class RoomTransitionAnimation : ScriptableObject
{
    [SerializeField] private AnimatorParameters _transitionInParameters;
    [SerializeField] private AnimatorParameters _transitionOutParameters;



    public void TransitionToRoom(int roomIndex)
    {

    }
}

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 12/24/25
/// </summary>
[System.Serializable]
public class AnimatorParameters
{
    [Header("General Animation Play Settings")]
    [SerializeField] private RuntimeAnimatorController _animator;
    [SerializeField] private string _stateName;
    [SerializeField] private int _layer;
    [SerializeField] private float _normalizedTimeOffset = 0.0f;

    [Header("Crossfade Settings")]
    [SerializeField] private float _normalizedTransitionDuration;
    [SerializeField] private float _normalizedTransitionTime = 0.0f;

    public void Play(Animator animator)
    {
        animator.Play(_stateName, _layer, _normalizedTimeOffset);
    }

    public void Crossfade(Animator animator)
    {
        animator.CrossFade(_stateName, _normalizedTransitionDuration, _layer, _normalizedTimeOffset, _normalizedTransitionTime);
    }

    public bool IsPlayingState(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(_layer);
        float normailzedTime = stateInfo.normalizedTime;
        bool matchingName = stateInfo.IsName(_stateName);

        //Debug.Log(normailzedTime);
        //Debug.Log(matchingName);

        return matchingName && normailzedTime < 1.0f;
    }
}
