using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float prevAspect;
    public int framesSinceTurn;
    public bool isSideways;
    //Ensure to make these variables of the level later on
    public float AreaWidth = 20f;
    public float AreaHeight = 16f;
    //Padding to so the game area doesn't take up the entire screen, giving UI some space
    public float AreaPadding = 4f;

    private void FixedUpdate()
    {
        bool aspectChange = cam.aspect != prevAspect;
        if (aspectChange | framesSinceTurn < 60)//Camera flipping logic. Optimize later and make additive to other camera actions
        {
            if (aspectChange) framesSinceTurn = 0;
            if (cam.aspect < AreaWidth / AreaHeight)
            {
                //Flipped Camera
                transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 90f), transform.eulerAngles, 0.90f);
                float size = Mathf.Max(AreaWidth + AreaPadding, (AreaHeight + AreaPadding) / cam.aspect);
                cam.orthographicSize = Mathf.Lerp(size, cam.orthographicSize, 0.90f);
                isSideways = true;
            }
            else
            {
                //Normal Camera
                transform.eulerAngles = Vector3.Lerp(Vector3.zero, transform.eulerAngles, 0.90f);
                cam.orthographicSize = Mathf.Lerp(AreaHeight + AreaPadding, cam.orthographicSize, 0.90f);
                isSideways = false;
            }
            prevAspect = cam.aspect;
            framesSinceTurn++;
        }
    }
}
