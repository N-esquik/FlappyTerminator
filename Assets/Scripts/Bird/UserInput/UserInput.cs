using UnityEngine;

public class UserInput : MonoBehaviour
{
    public const KeyCode Jump = KeyCode.Space;
    public const KeyCode Shooting = KeyCode.R;

    public event System.Action JumpPressed;
    public event System.Action ShootingPressed;

    private void Update()
    {
        if (GetKeyDown(Jump))
        {
            JumpPressed?.Invoke();
        }

        if (GetKeyDown(Shooting))
        {
            ShootingPressed?.Invoke();
        }
    }

    private bool GetKeyDown(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
