using UnityEngine;

using UnityEngine.Audio;

/// <summary>
/// Manager that starts and transitions between soundtrack clips.
/// 
/// Author: William Min
/// Date: 01/01/26
/// </summary>
public class SoundtrackManager : MonoBehaviour
{
    #region Serialized Fields


    [SerializeField] private float _transitionTime = 1f;                // 

    [Header("References")]
    [SerializeField] private AudioSource _firstMusic;                   // 
    [SerializeField] private AudioSource _secondMusic;                  // 
    [SerializeField] private AudioMixerSnapshot _firstMusicSnapshot;    // 
    [SerializeField] private AudioMixerSnapshot _secondMusicSnapshot;   // 


    #endregion

    #region Private Fields


    private bool _transitionToSecondAudio;  // 


    #endregion

    #region Monobehavior Callbacks


    private void Awake()
    {
        if (_firstMusic != null)
        {
            _firstMusic.loop = true;
        }

        if (_secondMusic != null)
        {
            _secondMusic.loop = true;
        }
    }


    #endregion

    #region Public Methods


    /// <summary>
    /// 
    /// </summary>
    /// <param name="clip"></param>
    public void TransitionToTrack(AudioClip clip)
    {
        _transitionToTrack(clip, _transitionToSecondAudio ? _secondMusic : _firstMusic, _transitionToSecondAudio ? _secondMusicSnapshot : _firstMusicSnapshot);
        _transitionToSecondAudio = !_transitionToSecondAudio;
    }


    #endregion

    #region Private Methods


    // 
    private void _transitionToTrack(AudioClip nextClip, AudioSource nextAudio, AudioMixerSnapshot nextMixer)
    {
        nextAudio.clip = nextClip;
        nextAudio.Play();

        nextMixer.TransitionTo(_transitionTime);
    }


    #endregion
}
