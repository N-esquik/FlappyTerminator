using UnityEngine;

public class UserInput : MonoBehaviour
{
    public const KeyCode Jump = KeyCode.Space;
    public const KeyCode Shooting = KeyCode.R;

    public event System.Action JumpPressed;
    public event System.Action ShootingPressed;

    private void Update()
    {
        if (SetKeyCode(Jump))
        {
            JumpPressed?.Invoke();
        }

        if (SetKeyCode(Shooting))
        {
            ShootingPressed?.Invoke();
        }
    }

    private bool SetKeyCode(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
