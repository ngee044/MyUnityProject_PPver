using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public float TiltAmount;
    public float xMax, xMin;
    public float zMax, zMin;

    public BoltPool PlayerBoltPool;
    public Transform FirePosition;
    public UIController uicontroller;

    private float CurrentReLoadTime;
    public float ReLoadTime;

    public int MaxHP;
    private int currentHp;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        CurrentReLoadTime = 0;
        this.transform.position = new Vector3(0, 2, 0);

        if (Speed <= 9)
            Speed = 10;

        if (TiltAmount < 30)
            TiltAmount = 30;
    }

    void OnEnable()
    {
        currentHp = MaxHP;
        uicontroller.ShowHpBar(1);
    }

	// Update is called once per frame
	void Update () {
        PlayerMoveEvent();
        FireEvent();
    }
    //
    //Game Event Function
    //
    private void FireEvent()
    {
        if (Input.GetButton("Fire1"))
        {
            if (CurrentReLoadTime <= 0)
            {
                Bolt newBolt = PlayerBoltPool.GetFromPool();
                SoundController.Instance.PlayeEffectSound(eEffectClips.WeaponPlayer);
                newBolt.transform.position = FirePosition.position;
                CurrentReLoadTime = ReLoadTime;
            }
        }
        CurrentReLoadTime -= Time.deltaTime;
    }

    private void PlayerMoveEvent()
    {
        float Hori = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(Hori, 0, Vert) * Speed; // 이동
        transform.rotation = Quaternion.Euler(0, 0, Hori * -TiltAmount); // 비행기 좌, 우 회전
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), 0, Mathf.Clamp(rb.position.z, zMin, zMax)); //맵을 벗어나지 못하게 하는 조건
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Hit(1);
            other.gameObject.SetActive(false);
        }
    }

    public void Hit(int dmg)
    {
        currentHp -= dmg;
        Debug.Log(currentHp + " is damage");
        uicontroller.ShowHpBar((float)currentHp / MaxHP);
        if (currentHp <= 0)
            this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameObject effect = EffectPool.Instance.GetFromPool((int)eTYPE_EFFECT.PLAYER_TYPE);
        SoundController.Instance.PlayeEffectSound(eEffectClips.ExpPlayer);
        effect.transform.position = this.transform.position;
        GameController.Instance.GameOver();
    }
}
