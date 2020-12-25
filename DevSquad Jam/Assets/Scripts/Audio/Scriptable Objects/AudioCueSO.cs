using System;
using UnityEngine;

/// <summary>
///  A collection of audio clips that are played in parallel, and support randomisation.
/// </summary>
[CreateAssetMenu(fileName = "newAudioCue",menuName = "Audio/Audio Cue")]
public class AudioCueSO : ScriptableObject
{
    public bool looping = false;
    [SerializeField] private AudioClipsGroup[] audioClipsGroups = default;
    public AudioClip[] GetClips()
    {
        int numberOfClips = audioClipsGroups.Length;
        AudioClip[] resultingClips = new AudioClip[numberOfClips];
        for (int i = 0; i < numberOfClips; i++)
        {
            resultingClips[i] = audioClipsGroups[i].GetNextClip();
         }
        return resultingClips;
    }
}
/// <summary>
/// Represents a group of AudioClips that can be treated as one, and provides automatic randomisation or sequencing based on the <c>SequenceMode</c> value.
/// </summary>
[Serializable]
public class AudioClipsGroup
{
    public SequenceMode sequenceMode = SequenceMode.RandomNoImmediateRepeat;
    public AudioClip[] audioClips;

    private int nextClipToPlay = -1;
    private int lastClipToPlay = -1;

    public AudioClip GetNextClip()
    {
        if (audioClips.Length == 1)
            return audioClips[0];
        if(nextClipToPlay == -1)
        {
            nextClipToPlay = (sequenceMode == SequenceMode.Sequential) ? 0 : UnityEngine.Random.Range(0, audioClips.Length);
            
        }
        else
        {
            switch(sequenceMode)
            {
                case SequenceMode.Random:
                    nextClipToPlay = UnityEngine.Random.Range(0, audioClips.Length);
                    break;
                case SequenceMode.RandomNoImmediateRepeat:
                    do
                    {
                        nextClipToPlay = UnityEngine.Random.Range(0, audioClips.Length);
                    } while (nextClipToPlay == lastClipToPlay);
                    break;
                case SequenceMode.Sequential:
                    nextClipToPlay = (int)Mathf.Repeat(++nextClipToPlay, audioClips.Length);
                    break;
            }
        }
        lastClipToPlay = nextClipToPlay;
        return audioClips[nextClipToPlay];
    }
   public enum SequenceMode
    {
        Random,
        RandomNoImmediateRepeat,
        Sequential
    }
}