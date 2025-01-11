using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Range(0,1f)]
    public float SpeedModifier = 0.5f;

    
    PlayerInput input;
    RectTransform playerRectTransform;
    float defaultSpeed;
    int curRoad;    //{0,1,2}

    bool canMove;
    bool isHitFront;
    bool isHitBack;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        playerRectTransform  = GetComponent<RectTransform>();

        defaultSpeed = ObjectPool.Instance.DefaultSpeed;

        curRoad = 1;
        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            HandleMove();
        }    
    

    }

    void HandleMove()
    {
        float horizontalInput = input.GetHorizontalMove();
        if(isHitFront)
        {
            horizontalInput = Math.Min(horizontalInput,0f);
        }
        if(isHitBack)
        {
            horizontalInput = Math.Max(0f,horizontalInput);
        }


        float horizontalMove = (defaultSpeed + horizontalInput * SpeedModifier * defaultSpeed )* Time.deltaTime;

        if(input.GetMoveUp())
        {
            if(curRoad != 0)
            {
                curRoad -= 1; 
            }

        }else if(input.GetMoveDown())
        {
            if(curRoad != 2)
            {
                curRoad += 1;
            }
        }

        float verticalMove = ObjectPool.Instance.Roads_y[curRoad];

        // 获取目标 Image 的 Y 坐标（世界坐标）
        Vector3 targetWorldPosition = ObjectPool.Instance.Roads[curRoad].position;

        Vector3 newPosition = playerRectTransform.position + new Vector3(horizontalMove,0f,0f);
        newPosition.y = targetWorldPosition.y;
        playerRectTransform.position = newPosition;

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.layer == LayerMask.NameToLayer("PlayerBorder"))
        {
            //input.DisableInput(1f);
            if(obj.name == "FrontBorder")
            {
                //Debug.Log("HitFront!");
                isHitFront = true;

                // force back a little distance
            }
            if(obj.name == "BackBorder")
            {
                //Debug.Log("HitBack!");
                isHitBack = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.layer == LayerMask.NameToLayer("PlayerBorder"))
        {
            //input.DisableInput(1f);
            if(obj.name == "FrontBorder")
            {
                //Debug.Log("HitFront!");
                isHitFront = false;

                // force back a little distance
            }
            if(obj.name == "BackBorder")
            {
                //Debug.Log("HitBack!");
                isHitBack = false;
            }
        }

    }


    public void DisableMove(float time)
    {
        StartCoroutine(StopMove(time));
    }

    IEnumerator StopMove(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }


}
