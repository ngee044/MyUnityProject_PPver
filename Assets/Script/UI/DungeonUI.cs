using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour {

    public Text QuestCondition;
    public Text Title;

    public Button Okbutton;
    public Text OkbuttonText;
    public Dropdown MonsterCounterComboBox;
    public Dropdown IsBossComboBox;
    public Dropdown DungeonLvComboBox;

    List<BattleMonster> list = new List<BattleMonster>();
    GameObject prefab;

    private void Start()
    {
        Init();
    }

    public bool exec
    {
        get { return this.gameObject.activeSelf; }
    }
   
    public int GetMonsterCount
    {
        get { return MonsterCounterComboBox.value; }
    }

    public int IsBoss
    {
        get { return IsBossComboBox.value; }
    }

    public int GetDungeonLv
    {
        get { return DungeonLvComboBox.value; }
    }

    public void Init()
    {
        this.transform.gameObject.SetActive(true);

        //default setting ui
        List<string> index = new List<string>();

        for (int i = 1; i < 9; i++)
            index.Add(i.ToString());

        MonsterCounterComboBox.AddOptions(index);

        MonsterCounterComboBox.value = 0;
        IsBossComboBox.value = 0;
        DungeonLvComboBox.value = 0;
    }

    public void Complet()
    {
        Debug.Log("Press ok bt");
        Title.text = "미션 성공!!";
        OkbuttonText.text = "재시작";
    }

    public void Fail()
    {
        Okbutton.gameObject.SetActive(false);
        Debug.Log("Press Return bt");
        Title.text = "미션 실패!!";
        OkbuttonText.text = "재시작";
    }

    public void On_Accept()
    {
        //for (int i = 0; i < MonsterCounterComboBox.value; i++)
        //{
        //    prefab = Resources.Load("monster") as GameObject;
        //    GameObject go = Instantiate(prefab) as GameObject;
        //    BattleMonster bm = go.GetComponent<BattleMonster>();
        //    list.Add(bm);
        //}

        //foreach(var i in list)
        //{
        //    i.init();
        //}
    }

    public void On_Rejct()
    {
        LoadingUi.LoadScene("MainGame");
    }
}
