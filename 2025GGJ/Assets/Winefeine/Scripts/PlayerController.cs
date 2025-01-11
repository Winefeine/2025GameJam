using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float DefaultSpeed = 10f;
    [Range(0,1f)]
    public float SpeedModifier = 0.5f;

    RectTransform playerRectTransform;
    PlayerInput input;




    void Start()
    {
        input = GetComponent<PlayerInput>();
        playerRectTransform  = GetComponent<RectTransform>();

    }

    void Update()
    {
            
        HandleMove();

    }

    void HandleMove()
    {
        //Vector3 newPosition = target.localPosition + direction * MaxSpeed * Time.deltaTime;
        //playerRectTransform.localPosition = newPosition;

        float horizontalMove = input.GetHorizontalMove() * SpeedModifier * DefaultSpeed * Time.deltaTime;

        if(input.GetMoveUp())
        {
            

        }else if(input.GetMoveDown())
        {
            

        }

        //Vector3 newPosition = playerRectTransform.localPosition + new;
            



    }


}
