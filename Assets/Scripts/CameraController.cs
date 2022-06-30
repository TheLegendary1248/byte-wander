using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float prevAspect;
    private void FixedUpdate()
    {
        if(cam.aspect != prevAspect)
        {
            if (cam.aspect < 1.22f)
            {
                transform.eulerAngles = new Vector3(0, 0, 90f);
                cam.orthographicSize = Mathf.Max(20f,16f / cam.aspect);
            }
            else
            {
                transform.eulerAngles = Vector2.zero;
                cam.orthographicSize = 16f;
            }
            prevAspect = cam.aspect;
        }
        
    }
}
