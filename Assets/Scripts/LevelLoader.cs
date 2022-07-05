using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class manages building "blocks" of the level and the level itself
/// </summary>
public class LevelLoader : MonoBehaviour
{
    static LevelLoader singleton;
    GameObject levelParent; //The scroller thing
    public static float y = 0;//FIX THIS
    float scrollOffset = 0;//Offsetter to avoid percision loss. IMPLEMENT LATER
    int section = 0;
    public float scrollSpeed;
    public GameObject tempBrickPrefab;
    public GameObject scroller;
    // Start is called before the first frame update
    void Start()
    {
        FileWanderer.GetNewPath();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scroller.transform.position = new Vector2(0, -(y -= scrollSpeed * Time.fixedDeltaTime));
        if (-y > section * 8f) //Create a new section
        {
            CreateNewSectionTemp();
        }
    }
    /// <summary>
    /// Creates a new section of the level
    /// </summary>
    void CreateNewSectionTemp()
    {
        GameObject sec = new GameObject("Section " + section);
        sec.transform.parent = this.transform;
        sec.transform.localPosition = new Vector2(0f, (section * 8f) + 32f);
        section++;
        for (int i = 0; i < 8; i++)
        {
            for (int k = 0; k < 42; k++)
            {
                if (FileWanderer.GetBytes(1)[0] > 100)
                {
                    GameObject gb = Instantiate(tempBrickPrefab, sec.transform);
                    gb.transform.localPosition = new Vector2(k - 20.5f, i);
                    Brick b = gb.GetComponent<Brick>();
                    b.boundMin = b.boundMax = new Vector2Int(k - 21, i);
                }
            }
        }
    }
}
