 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManagers : MonoBehaviour
{
    [Header("Audios Fonte")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    [Header("Audios")]
    public AudioClip background;
    public AudioClip item;
    public AudioClip damage;
    public AudioClip lost;
    public AudioClip win;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}
