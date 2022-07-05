using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Do I really need to explain this one?
/// </summary>
public class Paddle : MonoBehaviour
{
    public static Paddle singleton;
    void Start()
    {
        singleton = this;
    }
    private void OnDestroy()
    {
        singleton = null;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Camera cam = Camera.main;
        Vector3 pt = cam.ScreenToWorldPoint(Input.mousePosition);
        pt.y = -15;
        pt.z = 0;
        transform.localPosition = pt;
    }
}
