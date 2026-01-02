using UnityEngine;

using UnityEngine.Audio;

/// <summary>
/// 
/// 
/// Author: William Min
/// Date: 01/01/26
/// </summary>
public class SoundtrackManager : MonoBehaviour
{
    [SerializeField] private AudioSource _fromMusic;
    [SerializeField] private AudioSource _toMusic;
    [SerializeField] private AudioMixerGroup _fromMusicGroup;
    [SerializeField] private AudioMixerGroup _toMusicGroup;
    [SerializeField] private AudioMixerSnapshot _fromMusicSnapshot;
    [SerializeField] private AudioMixerSnapshot _toMusicSnapshot;
    [SerializeField] private float _transitionTime = 1f;



    [ContextMenu("Transition")]
    public void TransitionMusic()
    {
        //_fromMusic.outputAudioMixerGroup = _fromMusicGroup;
        //_toMusic.outputAudioMixerGroup = _toMusicGroup;

        //_fromMusic.Play();
        //_toMusic.Play();

        _toMusicSnapshot.TransitionTo(_transitionTime);
    }
}
