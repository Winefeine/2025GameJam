using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode Ability1;
    public KeyCode Ability2;
    public KeyCode Ability3;
    public KeyCode Ability4;

    [Tooltip("上下换路CD")]
    public float SwitchCD = 0.1f;
    float elaspedTime;
    bool canSwitch;
    bool canInput;

    void Start()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            DisableCursor();
        }

        elaspedTime = 0f;
        canSwitch = true;
        canInput = true;
    }
    
    void Update()
    {
        if(!canSwitch)
        {
            if(elaspedTime > SwitchCD)
            {
                elaspedTime = 0f;
                canSwitch = true;
            }
            elaspedTime += Time.deltaTime;
        }
    }

    public float GetHorizontalMove()
    {
        if (canInput)
        {
            float move = Input.GetAxisRaw("Horizontal");
            move = Math.Min(move, 1f);

            return move;
        }

        return 0f;
    }

    public bool GetMoveUp()
    {
        if(canInput && canSwitch)
        {
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                elaspedTime = 0f;
                canSwitch = false;
                return true;
            }
        }

        return false;
    }

    public bool GetMoveDown()
    {
        if(canInput && canSwitch)
        {
            if(Input.GetAxisRaw("Vertical") < 0)
            {
                elaspedTime = 0f;
                canSwitch = false;
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

    public void DisableInput(float time)
    {
        StartCoroutine(StopInput(time));
    }


    IEnumerator StopInput(float time)
    {
        canInput = false;
        yield return new WaitForSeconds (time);
        canInput = true;
    }


}
