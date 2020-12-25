using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
	[Header("SoundEmitters pool")]
	[SerializeField] private SoundEmitterFactorySO factory = default;
	[SerializeField] private SoundEmitterPoolSO pool = default;
	[SerializeField] private int initialSize = 10;

	[Header("Listening on channels")]
	[Tooltip("The SoundManager listens to this event, fired by objects in any scene, to play SFXs")]
	[SerializeField] private AudioCueEventChannelSO SFXEventChannel = default;
	[Tooltip("The SoundManager listens to this event, fired by objects in any scene, to play Music")]
	[SerializeField] private AudioCueEventChannelSO musicEventChannel = default;


	[Header("Audio control")]
	[SerializeField] private AudioMixer audioMixer = default;
	[Range(0f, 1f)]
	[SerializeField] private float masterVolume = 1f;
	[Range(0f, 1f)]
	[SerializeField] private float musicVolume = 1f;
	[Range(0f, 1f)]
	[SerializeField] private float sfxVolume = 1f;

	
	private void Awake()
	{
		SFXEventChannel.OnAudioCueRequested += PlayAudioCue;
		musicEventChannel.OnAudioCueRequested += PlayAudioCue;
		DontDestroyOnLoad(this.gameObject);
	}

	private void OnValidate()
	{
		if (Application.isPlaying)
		{
			SetGroupVolume("MasterVolume", masterVolume);
			SetGroupVolume("BGMVolume", musicVolume);
			SetGroupVolume("SFXVolume", sfxVolume);
		}
	}

	public void SetGroupVolume(string parameterName, float normalizedVolume)
	{
		bool volumeSet = audioMixer.SetFloat(parameterName, NormalizedToMixerValue(normalizedVolume));
		if (!volumeSet)
			Debug.LogError("AudioMixer parameter was not found");
	}
	public float GetGroupVolume(string parameterName)
	{
		if (audioMixer.GetFloat(parameterName, out float rawVolume))
		{
			return MixerValueToNormalized(rawVolume);
		}
		else
		{
			Debug.LogError("The AudioMixer parameter was not found");
			return 0f;
		}
	}
	private float MixerValueToNormalized(float mixerValue)
	{
		//from [-80dB to 0dB] to [0  to 1]
		return 1f + (mixerValue / 80f);
	}
	private float NormalizedToMixerValue(float normalizedValue)
	{
		return Mathf.Log10(normalizedValue) * 20;
	}
	/// <summary>
	///  Plays an AudioCue by requesting the appropriate number of SoundEmitters from the pool.
	/// </summary>
	/// <param name="audioCue"></param>
	/// <param name="settings"></param>
	/// <param name="position"></param>
	public void PlayAudioCue(AudioCueSO audioCue, AudioConfigurationSO settings, Vector3 position = default)
	{
		AudioClip[] clipsToPlay = audioCue.GetClips();
		int numberOfClips = clipsToPlay.Length;
		for (int i = 0; i < numberOfClips; i++)
		{
			SoundEmitter soundEmitter = pool.Request();
			if (soundEmitter != null)
			{
				soundEmitter.PlayAudioClip(clipsToPlay[i], settings, audioCue.looping, position);
				if (!audioCue.looping)
					soundEmitter.OnSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
			}

		}
	}
	private void OnSoundEmitterFinishedPlaying(SoundEmitter soundEmitter)
	{
		soundEmitter.OnSoundFinishedPlaying -= OnSoundEmitterFinishedPlaying;
		soundEmitter.Stop();
		pool.Return(soundEmitter);
	}
}

