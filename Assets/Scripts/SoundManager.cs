using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //to make this accessible from everywhere easy -> make this a singelton
    //Singeltons only if i am really sure, that there is no other instance of this ever!!
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void PlaySoundClip(AudioClip audio, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audio;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource, clipLength);
    }

    public void PlayRandomClip(AudioClip[] audios, Transform spawnTransform, float volume)
    {
        int randomIndex = UnityEngine.Random.Range(0, audios.Length);
        PlaySoundClip(audios[randomIndex], spawnTransform, volume);
    }
}
