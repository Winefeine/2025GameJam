using Unity.VisualScripting;
using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("允许障碍物移动")]
    public bool CanMove = false;
    [Tooltip("正x轴速度")]
    public float MoveSpeed = 100f;

    RectTransform rect;
    Camera mainCam;    
    bool isInView;
    //bool wasInView;
    bool isMoving;
    

    void Start()
    {
        rect = GetComponent<RectTransform>();
        mainCam = ObjectPool.Instance.MainCamera;

        //wasInView = isInView;
    }

    void Update()
    {
        JudgeInView();
        if(isInView && CanMove)
        {
            Move();
        }
    }

    private bool JudgeInView()
    {
        if (mainCam == null || rect == null)
        {
            isInView = false;
            return false;
        } 
        
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        // 检查四个角是否有一个在相机视口范围内
        foreach (Vector3 corner in corners)
        {
            Vector3 viewportPos = mainCam.WorldToViewportPoint(corner);

            // 如果至少一个角在 (0,0) 到 (1,1) 的视口范围内，则说明 Image 可见
            if (viewportPos.x >= 0 && viewportPos.x <= 1 &&
                viewportPos.y >= 0 && viewportPos.y <= 1 &&
                viewportPos.z > 0) // 确保在相机前方
            {
                isInView = true;
                return true;
            }
        }

        isInView = false;
        return false;
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + new Vector3(MoveSpeed * Time.deltaTime,0f,0f);
        
        transform.position = newPosition;
    }


    // public virtual void OnEnterView()
    // {
        
    //     Debug.Log(gameObject.name + " Enter the view.");
    // }

    // public virtual void OnExitView()
    // {
    //     Debug.Log(gameObject.name + " Exit from the view.");
    // }
}
