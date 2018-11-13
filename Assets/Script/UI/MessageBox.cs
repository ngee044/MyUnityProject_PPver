using UnityEngine;
using UnityEngine.UI;

public class MsgOptions
{
    public string cancelButtonTitle;
    //Cancel Delegate
    public System.Action CancelButtonDelegate;
    //Ok button Name
    public string okButtonTitle;
    //Ok button Delegate
    public System.Action OkButtonDelegate;
}

public class MessageBox : MonoBehaviour {
    public Text titleLabel;
    public Text messageLabel;
    public Button cancelButton;
    public Text cancelLabel;
    public Button okButton;
    public Text OkButtonLabel;

    private static GameObject prefab;
    private System.Action CancelButtonDelegate;
    private System.Action OkButtonDelegate;

    //alert를 표시하는 static 메서드

    public static MessageBox Show(
        string title, string message, MsgOptions options = null)
    {
       if(prefab == null)
        {
            prefab = Resources.Load("MessageBox") as GameObject;
        }

        GameObject go = Instantiate(prefab) as GameObject;
        MessageBox MsgView = go.GetComponent<MessageBox>();
        MsgView.UpdateContent(title, message, options);
        
        return MsgView;
    }

    public void UpdateContent(
        string title, string message, MsgOptions options = null)
    {
        titleLabel.text = title;
        messageLabel.text = message;
        if (options != null)
        {
            //표시 옵션이 있을 때 내용에 맞춰 버튼 표시
            cancelButton.transform.gameObject.SetActive(
            options.okButtonTitle != null || options.cancelButtonTitle != null);

            cancelButton.gameObject.SetActive(options.cancelButtonTitle != null);
            cancelLabel.text = options.cancelButtonTitle ?? "";
            CancelButtonDelegate = options.CancelButtonDelegate;

            okButton.gameObject.SetActive(options.okButtonTitle != null);
            OkButtonLabel.text = options.okButtonTitle ?? "";
            OkButtonDelegate = options.OkButtonDelegate;
        }
        else
        {
            //Basic Alert
            cancelButton.gameObject.SetActive(false);
            okButton.gameObject.SetActive(true);
            OkButtonLabel.text = "Ok";
        }
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }

    public void OnPressCancelButton()
    {
        if (CancelButtonDelegate != null)
        {
            CancelButtonDelegate.Invoke();
        }
        Dismiss();
    }

    public void OnPressOkButton()
    {
        if (OkButtonDelegate != null)
        {
            OkButtonDelegate.Invoke();
        }
        Dismiss();
    }
}
