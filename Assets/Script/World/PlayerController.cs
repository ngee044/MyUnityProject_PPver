using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public Rigidbody rigid;
    float _vertical;
    float _horizontal;

    float moveX;
    float moveZ;
    float speedX = 95;
    float speedZ = 120;
    
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        //if(Input.GetMouseButtonUp(1))
        {
            animator.Play("Jump", -1, 0);
            CharacterMgr.GetInstance.GetPlayer.PlayerExp += 30;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Q");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("E");
        }
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        animator.SetFloat("h", _horizontal);
        animator.SetFloat("v", _vertical);

        moveX = _horizontal * speedX * Time.deltaTime;
        moveZ = _vertical   * speedZ * Time.deltaTime;

        if (moveZ <= 0)
        {
            moveX = 0;
        }

        rigid.velocity = new Vector3(moveX, 0, moveZ);
    }

    private void OnCollisionEnter(Collision rect)
    {
        //충돌했을때
        if(rect.collider.tag == "Collision")
        {
            animator.Play("DAMAGED01", -1, 0);
            this.transform.Translate(Vector3.back * 75 * Time.deltaTime);
            CharacterMgr.GetInstance.GetPlayer.HP -= CharacterMgr.GetInstance.GetMonster[0].ATK;
            Debug.Log("Collision");
        }
    }

    private void OnCollisionStay(Collision rect)
    {
        //충돌 중일 때
        if (rect.collider.tag == "Collision")
        {
        
        }
        else if(rect.collider.tag == "ShopNpc")
        {

            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("On Click NPC");
                Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(MouseRay, out hit, 1000.0f, 1 << LayerMask.NameToLayer("NPC_ClickLayer")))
                {
                    UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].SetActive(true);
                }
            }
        }
    }

    private void OnCollisionExit(Collision rect)
    {
        //충돌끝날때
        if (rect.collider.tag == "Collision")
        {

        }
        else if (rect.collider.tag == "ShopNpc")
        {
            if(UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].activeSelf == true)
            {
                UiPanel.GetInstance.ListUi[(int)eTypeUi.eType_Shop].SetActive(false);
            }
        }
    }


}
