using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class AndroidTest : MonoBehaviour
{
    public InputField SetLogInputField;
    public InputField SetNameInputField;
    public InputField GetLogInputField;
    public InputField GetNameInputField;
    public InputField ShowToastInputField;

    public Button SetLogButton;
    public Button SetNameButton;
    public Button GetLogButton;
    public Button GetNameButton;
    public Button ShowToastButton;
    public Button RequestPermissionButton;

    private AndroidJavaClass _androidJavaClass = null;
    private AndroidJavaObject _androidJavaObject = null;
    
    private void Start()
    {
        _androidJavaClass = new AndroidJavaClass("com.pub.unity2android.Test");
        _androidJavaObject = new AndroidJavaObject("com.pub.unity2android.Test");

        SetLogButton.onClick.AddListener(OnClickSetLogButton);
        SetNameButton.onClick.AddListener(OnClickSetNameButton);
        GetLogButton.onClick.AddListener(OnClickGetLogButton);
        GetNameButton.onClick.AddListener(OnClickGetNameButton);
        ShowToastButton.onClick.AddListener(OnClickShowToastButton);
        RequestPermissionButton.onClick.AddListener(OnClickRequestPermissionButton);
    }

    private void OnClickRequestPermissionButton()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera)) 
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    private void OnClickShowToastButton()
    {
#if UNITY_ANDROID
        _androidJavaObject.Call("ShowToast", ShowToastInputField.text);
#endif
    }

    public void OnClickSetLogButton()
    {
#if UNITY_ANDROID
        _androidJavaClass.CallStatic("SetLog", SetLogInputField.text);
#endif
    }
    
    public void OnClickSetNameButton()
    {
#if UNITY_ANDROID
        _androidJavaObject.Call("SetName", SetNameInputField.text);
#endif
    }
    
    public void OnClickGetLogButton()
    {
#if UNITY_ANDROID
        GetLogInputField.text = _androidJavaClass.CallStatic<string>("GetLog");
#endif
    }

    private void OnClickGetNameButton()
    {
#if UNITY_ANDROID
        GetNameInputField.text = _androidJavaObject.Call<string>("GetName");
#endif
    }
}