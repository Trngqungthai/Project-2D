using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public Slider volumeSlider;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        PlayRandomAudio();
    }

    private void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayRandomAudio()
    {
        if (audioClips.Count > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Count);
            AudioClip randomClip = audioClips[randomIndex];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}