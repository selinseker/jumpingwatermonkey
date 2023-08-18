using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform Target;

    public float CameraSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position = Vector3.Slerp(transform.position, new Vector3(Target.position.x, Target.position.y, transform.position.z), CameraSpeed);
        
    }
}
