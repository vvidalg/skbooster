using UnityEngine;

public class MiniGameUIManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}