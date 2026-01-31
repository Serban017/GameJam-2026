using UnityEngine;
using TMPro;

public class PasscodeUI : MonoBehaviour
{
    public static PasscodeUI instance;

    public GameObject panel;
    public TMP_InputField inputField;

    Keypad currentKeypad;

    void Awake()
    {
        instance = this;
        panel.SetActive(false);
    }

    public void Open(Keypad keypad)
    {
        currentKeypad = keypad;
        panel.SetActive(true);
        inputField.text = "";
        inputField.ActivateInputField();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Submit()
    {
        currentKeypad.TryCode(inputField.text);
    }

    public void Close()
    {
        panel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
