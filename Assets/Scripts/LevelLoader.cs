using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class manages building "blocks" of the level
/// </summary>
public class LevelLoader : MonoBehaviour
{
    static LevelLoader singleton;
    GameObject levelParent; //The scroller thing
    float y = 0;
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FileWanderer.GetNewPath();
        FileWanderer.GetNewPath();
        FileWanderer.GetNewPath();
        FileWanderer.GetNewPath();
        FileWanderer.GetNewPath();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(0, y -= scrollSpeed * Time.fixedDeltaTime);
    }
}
