using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListElement : MonoBehaviour
{
    
    public Image icon;
    public Text title, contents, purchase,cost;
    public Button purchaseButton;
    private int id;
    private Delegates.VoidCallBackWithInt callback;

    public void Init
        (Sprite inputIcon,
        string titleText,
        string costText,
        string contentsText,
        string purchaseText,
        int inputID,
        Delegates.VoidCallBackWithInt inputCallback)
    {
        icon.sprite = inputIcon;
        title.text = titleText;
        cost.text = costText;
        contents.text = contentsText;
        purchase.text = purchaseText;
        callback = inputCallback;
        id = inputID;
        purchaseButton.onClick.AddListener(() => { inputCallback(id); });
        
    }

    public void ChangeCallBack(Delegates.VoidCallBackWithInt i)
    {
        callback = i;
    }

    public void Renew(string costText, string contentsText, string purchaseText)
    {
        cost.text = costText;
        contents.text = contentsText;
        purchase.text = purchaseText;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
