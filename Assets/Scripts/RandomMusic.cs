﻿using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] Music;
    void Start()
    {
        if (Settings.MuteMusic)
        {
            return;
        }
        int select = Random.Range(0, Music.Length);
        var audio = gameObject.GetComponent<AudioSource>();
        audio.clip = Music[select];
        audio.Play();
    }
}
