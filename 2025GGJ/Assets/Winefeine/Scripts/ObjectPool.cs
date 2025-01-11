using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [Header("Adjustable Parameters")]
    public float DefaultSpeed = 100f;
    public float StopDuration = 1f;

    [Header("Pool")]
    public RectTransform[] Roads = new RectTransform[3];
    //[HideInInspector]
    public float[] Roads_y = new float[3];
    public Camera MainCamera; 
    public PlayerController PlayerController;
    public CameraController CameraController;
    public BorderController BorderController;





    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GetRoads_y();
    }

    void GetRoads_y()
    {
        // if(Roads[0] != null && Roads[1] != null && Roads[2] != null)
        // {
        //     for(int i = 0;i < 3;i++)
        //     {
        //         Roads_y[i] = Roads[i].position.y;
        //         Debug.Log(Roads_y[i]);
        //     }
        // }
        
    }    



}
