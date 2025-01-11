using System.Collections;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    float defaultSpeed;
    bool canMove;

    void Start()
    {
        defaultSpeed = ObjectPool.Instance.DefaultSpeed;

        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            BorderMove();
        }        
    }

    void BorderMove()
    {
        Vector3 newPosition = transform.position + new Vector3(defaultSpeed * Time.deltaTime,0f,0f);

        transform.position = newPosition;
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
