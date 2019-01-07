﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBGMClips
{
    BG01_BACKGROUND,
}

public enum eEffectClips
{
    ExpRock,
    ExpEnemy,
    ExpPlayer,
    WeaponEnemy,
    WeaponPlayer,
}

public class SoundController : MonoBehaviour {

    public static SoundController Instance;

    public AudioSource BGM, Effect;
    public AudioClip[] BGMClip, EffectClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void PlayeBGM(eBGMClips id)
    {
        BGM.clip = BGMClip[(int)id];
        BGM.volume = 100 / 100;
        BGM.Play();
        //BGM.Stop();
    }

    public void PlayeEffectSound(eEffectClips id)
    {
        Effect.PlayOneShot(EffectClip[(int)id]);
    }

    void Start()
    {

    }


    
}
