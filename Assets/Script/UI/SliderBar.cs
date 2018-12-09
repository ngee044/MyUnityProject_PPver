using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour {

    public Slider HP;
    public Text HP_label;
    public Slider MP;
    public Text MP_label;
    public Slider EXP;
    public Text EXP_label;
    public Text Level_label;
    public Slider MonsterHP;

    float _HPmax;
    float _MPmax;
    float _EXPmax;

    // Use this for initialization
    void Start () {
        MonsterHP.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        RefreshOfPlayerUI();
    }

    private void RefreshOfPlayerUI()
    {
        _HPmax = CharacterMgr.GetInstance.GetPlayer.HPMAX;
        _MPmax = CharacterMgr.GetInstance.GetPlayer.MPMAX;
        _EXPmax = CharacterMgr.GetInstance.GetPlayer.PlayerExpMax;

        HP.value = CharacterMgr.GetInstance.GetPlayer.HP / _HPmax;
        MP.value = CharacterMgr.GetInstance.GetPlayer.MP / _MPmax;
        EXP.value = CharacterMgr.GetInstance.GetPlayer.PlayerExp / _EXPmax;

        HP_label.text = CharacterMgr.GetInstance.GetPlayer.HP.ToString() + " / " + _HPmax.ToString();
        MP_label.text = CharacterMgr.GetInstance.GetPlayer.MP.ToString() + " / " + _MPmax.ToString();
        EXP_label.text = CharacterMgr.GetInstance.GetPlayer.PlayerExp.ToString() + " / " + _EXPmax.ToString();
        Level_label.text = "LV" + CharacterMgr.GetInstance.GetPlayer.PlayerLevel.ToString();   
    }
}
