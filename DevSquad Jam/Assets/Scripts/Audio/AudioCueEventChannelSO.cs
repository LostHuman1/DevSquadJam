using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Event which AudioCue send message to play SFX and music 
/// </summary>
[CreateAssetMenu(menuName = "Events/AuddioCue Event Channel")]
public class AudioCueEventChannelSO : ScriptableObject
{
    public UnityAction<AudioCueSO, AudioConfigurationSO, Vector3> OnAudioCueRequested;
    public void RaiseEvent(AudioCueSO audioCue, AudioConfigurationSO audioConfiguration, Vector3 position)
    {
        if (OnAudioCueRequested != null)
        {
            OnAudioCueRequested.Invoke(audioCue, audioConfiguration, position);
        }
        else
        {
            Debug.LogWarning("An AudioCue was requested, but nobody picked it up. " +
                "Check why there is no AudioManager already loaded, " +
                "and make sure it's listening on this AudioCue Event channel.");
        }
    }
}
