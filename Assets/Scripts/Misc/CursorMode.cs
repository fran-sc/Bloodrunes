using UnityEngine;

public class CursorMode : MonoBehaviour
{
    
    void Start()
    {
        SetLockMode(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetLockMode(false);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SetLockMode(true);
        }        
    }

    void SetLockMode(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
