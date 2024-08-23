using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;

    [Header("----------Audio Clip----------")]
    public AudioClip BackgroundMusic;


private void Start()
    {
        musicSource.clip = BackgroundMusic;
        musicSource.Play();
    }
    private void Update()
    {
        musicSource.volume = MenuPincipalManager.Instance.musicSlider.value;
    }

}


