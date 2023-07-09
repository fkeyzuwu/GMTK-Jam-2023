using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] sounds;

    private Dictionary<string, Sound> soundsDict = new Dictionary<string, Sound>();

    [Header("Music Sources")]
    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource gameMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            float volume = sound.volume;
            audioSource.volume = volume;
            sound.source = audioSource;
            soundsDict[sound.name] = sound; 
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = soundsDict[name];
        sound.source.PlayOneShot(sound.GetClip());
    }
    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
        gameMusic.Stop();
    }

    public void PlayGameMusic()
    {
        mainMenuMusic.Stop();
        gameMusic.Play();
    }

    [System.Serializable]
    public class Sound
    {
        public string name;
        [HideInInspector] public AudioSource source;
        public AudioClip[] clips;
        private int currentClipIndex = -1;
        [Range(0.0001f, 1f)] public float volume;

        public AudioClip GetClip()
        {
            if (currentClipIndex + 1 < clips.Length)
            {
                currentClipIndex++;
            }
            else
            {
                currentClipIndex = 0;
            }

            return clips[currentClipIndex];
        }
    }
}

