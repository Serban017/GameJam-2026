using UnityEngine;

public class Keypad : InteractiveObject
{
    public Door linkedDoor;
    public string correctCode = "1234";

    public override void OnInteract()
    {
        PasscodeUI.instance.Open(this);
    }

    public void TryCode(string input)
    {
        if (input == correctCode)
        {
            linkedDoor.OpenDoor();
            PasscodeUI.instance.Close();
        }
        else
        {
            Debug.Log("Wrong code");
        }
    }
}
