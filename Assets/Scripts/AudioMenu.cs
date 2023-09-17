using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioMenu : MonoBehaviour
{
    [Header("Audios Fonte")]
    [SerializeField] AudioSource musicMenu;
    

    [Header("Audios")]
    public AudioClip menu;

    private void Start()
    {
        musicMenu.clip = menu;
        musicMenu.Play();
    }


}
