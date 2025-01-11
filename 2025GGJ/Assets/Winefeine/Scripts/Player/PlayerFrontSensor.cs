using Unity.VisualScripting;
using UnityEngine;

public class PlayerFrontSensor : MonoBehaviour
{


    PlayerController playerController;
    float stopDuration;

    void Start ()
    {
        playerController = transform.parent.GetComponent<PlayerController>();

        stopDuration = ObjectPool.Instance.StopDuration;
    }

    void OnHitObstacle(BaseObstacle obstacle)
    {
        //Disable Obstacle's Collider
        obstacle.GetComponent<BoxCollider2D>().enabled = false;    
        //Player Stop
        playerController.DisableMove(stopDuration);
        //Camera Stop
        ObjectPool.Instance.CameraController.DisableMove(stopDuration);
        ObjectPool.Instance.BorderController.DisableMove(stopDuration);

        Debug.Log("Hit "+obstacle.gameObject.name);
        //Hit Count++
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.layer == LayerMask.NameToLayer("Obstacle"))
        {
            OnHitObstacle(obj.GetComponent<BaseObstacle>());
        }        
        
    }


}
