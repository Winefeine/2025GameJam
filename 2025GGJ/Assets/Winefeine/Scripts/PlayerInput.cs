using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode Ability1;
    public KeyCode Ability2;
    public KeyCode Ability3;
    public KeyCode Ability4;

    void Start()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            DisableCursor();
        }
    }
    
    public float GetHorizontalMove()
    {
        if (CanProcessInput())
        {
            float move = Input.GetAxisRaw("Horizontal");
            move = Math.Min(move, 1f);

            return move;
        }

        return 0f;
    }

    public bool GetMoveUp()
    {
        if(CanProcessInput())
        {
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                return true;
            }
        }

        return false;
    }

    public bool GetMoveDown()
    {
        if(CanProcessInput())
        {
            if(Input.GetAxisRaw("Vertical") < 0)
            {
                return true;
            }
        }
        
        return false;
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public bool CanProcessInput()
    {
        return Cursor.lockState == CursorLockMode.Locked;
    }


}
