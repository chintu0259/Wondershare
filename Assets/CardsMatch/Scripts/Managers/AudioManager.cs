using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioSource audioSource;

	public AudioClip[] sounds;

    void Awake()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

    }

    public void Play(int soundIndex)
    {
		audioSource.PlayOneShot(sounds[soundIndex]);
    }
}
