using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]
public class SoundEmitter : MonoBehaviour
{
    private AudioSource audioSource;
    public event UnityAction<SoundEmitter> OnSoundFinishedPlaying;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    /// <summary>
    /// Instructs the Audiosource to play a single clip 
    /// </summary>
    /// <param name="clip">audioclip</param>
    /// <param name="hasToLoop">loopable</param>
    /// <param name="position">position in 3D space</param>
    public void PlayAudioClip(AudioClip clip,AudioConfigurationSO settings, bool hasToLoop, Vector3 position = default)
    {
        audioSource.clip = clip;
        settings.ApplyTo(audioSource);
        audioSource.transform.position = position;
        audioSource.loop = hasToLoop;
        audioSource.Play();
        if (!hasToLoop)
        {
            StartCoroutine(FinishedPlaying(clip.length));
        }
    }
    /// <summary>
    /// Used when the game is resume
    /// </summary>
    public void Resume()
    {
        audioSource.Play();
    }
    /// <summary>
    /// When the game pause
    /// </summary>
    public void Pause()
    {
        audioSource.Pause();
    }
    /// <summary>
    /// When SFX finished playing
    /// </summary>
    public void Stop()
    {
        audioSource.Stop();
    }

    public bool IsInUse()
    {
        return audioSource.isPlaying;
    }

    IEnumerator FinishedPlaying(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        OnSoundFinishedPlaying.Invoke(this); //Audio Manager will pick this up
    }
}
