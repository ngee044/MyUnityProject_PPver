using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInfoUi : MonoBehaviour {

    public Text Name;
    public Text Level;
    public Text ATK;
    public Text DEF;
    public Text MyGold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Name.text = CharacterMgr.GetInstance.GetPlayer.NAME;
        Level.text = CharacterMgr.GetInstance.GetPlayer.PlayerLevel.ToString();
        ATK.text = CharacterMgr.GetInstance.GetPlayer.ATK.ToString();
        DEF.text = CharacterMgr.GetInstance.GetPlayer.DEF.ToString();
        MyGold.text = CharacterMgr.GetInstance.GetPlayer.PlayerItem.Gold.ToString();
    }

    public void on_close_clicked()
    {
        this.transform.gameObject.SetActive(false);
    }
}
