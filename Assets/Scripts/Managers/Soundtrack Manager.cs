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


    [SerializeField] private float _transitionTime = 1f;                // Time to transition between soundtracks

    [Header("References")]
    [SerializeField] private AudioSource _firstMusic;                   // First audio source for transition
    [SerializeField] private AudioSource _secondMusic;                  // Second audio source for transition
    [SerializeField] private AudioMixerSnapshot _firstMusicSnapshot;    // Snapshot in mixer when the first audio is on and the second audio is off
    [SerializeField] private AudioMixerSnapshot _secondMusicSnapshot;   // Snapshot in mixer when the second audio is on and the first audio is off


    #endregion

    #region Private Fields


    private bool _transitionToSecondAudio;  // True if the manager will transition to the second audio source


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
    /// Transitions to the next audio clip.
    /// </summary>
    /// <param name="clip">Next looping audio clip to transition to</param>
    public void TransitionToTrack(AudioClip clip)
    {
        _transitionToTrack(clip, _transitionToSecondAudio ? _secondMusic : _firstMusic, _transitionToSecondAudio ? _secondMusicSnapshot : _firstMusicSnapshot);
        _transitionToSecondAudio = !_transitionToSecondAudio;
    }


    #endregion

    #region Private Methods


    // Transitions to a given audio source with a new audio clip
    private void _transitionToTrack(AudioClip nextClip, AudioSource nextAudio, AudioMixerSnapshot nextMixer)
    {
        nextAudio.clip = nextClip;
        nextAudio.Play();

        nextMixer.TransitionTo(_transitionTime);
    }


    #endregion
}
