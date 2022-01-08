using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class IosTest : MonoBehaviour
{
    public InputField InputField;
    public Text Text;
    public Button Button;

    [DllImport("__Internal")]
    static extern void IOSLog(string message);

    private void Start()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        IOSLog(InputField.text);
    }

    /// <summary>
    /// ios调用交互
    /// </summary>
    /// <param name="str"></param>
    public void IOSToUnity(string str)
    {
        Text.text = str;
    }
}
