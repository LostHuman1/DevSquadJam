using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCue : MonoBehaviour
{
	[Header("Sound definition")]
	[SerializeField] private AudioCueSO audioCue = default;
	[SerializeField] private bool playOnStart = false;

	[Header("Configuration")]
	[SerializeField] private AudioCueEventChannelSO audioCueEventChannel = default;
	[SerializeField] private AudioConfigurationSO audioConfiguration = default;

	private void Start()
	{
		if (playOnStart)
			PlayAudioCue();
	}

	public void PlayAudioCue()
	{
		audioCueEventChannel.RaiseEvent(audioCue, audioConfiguration, transform.position);
	}
}
