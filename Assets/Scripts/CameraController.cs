using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float prevAspect;
    public int framesSinceTurn;
    public bool isSideways;
    private void FixedUpdate()
    {
        bool aspectChange = cam.aspect != prevAspect;
        if (aspectChange | framesSinceTurn < 60)//Camera flipping logic. Optimize later and make additive to other camera actions
        {
            if (aspectChange) framesSinceTurn = 0;
            if (cam.aspect < 1.22f)
            {
                //Flipped Camera
                transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 90f), transform.eulerAngles, 0.90f);
                float size = Mathf.Max(20f, 16f / cam.aspect);
                cam.orthographicSize = Mathf.Lerp(size, cam.orthographicSize, 0.90f);
                isSideways = true;
            }
            else
            {
                //Normal Camera
                transform.eulerAngles = Vector3.Lerp(Vector3.zero, transform.eulerAngles, 0.90f);
                cam.orthographicSize = Mathf.Lerp(16f, cam.orthographicSize, 0.90f);
                isSideways = false;
            }
            prevAspect = cam.aspect;
            framesSinceTurn++;
        }
    }
}
