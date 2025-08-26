using UnityEngine;

public class UserInput : MonoBehaviour
{
    public const KeyCode KeySpace = KeyCode.Space;
    public const KeyCode KeyR = KeyCode.R;

    public bool SetKeyCode(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
