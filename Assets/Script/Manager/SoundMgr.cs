using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public AudioSource EffectClip;
    public AudioSource BgmClip;

	private static SoundMgr instance;
	public static SoundMgr GetInstance()
	{
		if (!instance)
		{
			instance = GameObject.FindObjectOfType(typeof(SoundMgr)) as SoundMgr;
			if (!instance)
				Debug.Log("ERROR");
		}

		return instance;
	}
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (BgmClip)
            {
                if (BgmClip.mute)
                    BGMMute(false);
                else
                    BGMMute(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (BgmClip)
            {
                if(BgmClip.isPlaying)
                    BGMStop();
                else
                    BGMPlay();
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            ClickSound();
        }
    }

    public void ClickSound()
    {
        if (EffectClip)
        {
            EffectClip.Play();
        }
    }

    public void BGMMute(bool isMute)
	{
        if (BgmClip)
        {
            BgmClip.mute = isMute;
        }
	}

	public void BGMPlay()
	{
        if (BgmClip)
            BgmClip.Play();

    }

	public void BGMStop()
	{
        if (BgmClip)
            BgmClip.Stop();
    }

}
