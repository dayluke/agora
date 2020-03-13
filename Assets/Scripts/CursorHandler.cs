using UnityEngine;

public static class CursorHandler
{
    public static void ToggleCursor(bool toggle)
    {
        Cursor.visible = toggle;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
    }
}