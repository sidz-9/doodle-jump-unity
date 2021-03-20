using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;

    public float smoothSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(targetPlayer.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, targetPlayer.position.y, transform.position.z);
            // transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
            transform.position = newPos;
        }
    }
}
