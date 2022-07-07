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
    public float scrollSpeed;
    public GameObject tempBrickPrefab;
    public GameObject scroller;
    public static GameObject currentSection { private set; get; }
    public static int sectionNum { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        FileWanderer.GetNewPath();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scroller.transform.position = new Vector2(0, -(y -= scrollSpeed * Time.fixedDeltaTime));
        if (-y > sectionNum * 8f) //Create a new section
        {
            CreateNewSectionTemp();
        }
    }
    /// <summary>
    /// Creates a new section of the level
    /// </summary>
    void CreateNewSectionTemp()
    {   
        currentSection = new GameObject("Section " + sectionNum);
        currentSection.transform.parent = this.transform;
        currentSection.transform.localPosition = new Vector2(0f, (sectionNum * 8f) + 32f);
        sectionNum++;
        TempFormat.Load(new int[]{ 42, 42, 42, 42, 42, 42, 42, 42});
    }
}
