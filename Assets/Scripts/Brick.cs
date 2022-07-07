using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Brick : MonoBehaviour, IComparer<Brick>
{
    public BoxCollider2D col;
    public GameObject graphic;
    int health;
    public Vector2Int boundMin; //Lower left corner of the brick
    public Vector2Int boundMax; //Upper right corner of the brick
    public static AsyncOperationHandle prefab;
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        prefab = Addressables.LoadAssetAsync<GameObject>(@"Assets/Prefabs/Brick.prefab");
    }
    void Start()
    {
        BrickManager.RegisterBrick(this);
        col.size = boundMax - boundMin;
        graphic.transform.localScale = col.size;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    //Simplify later, or optimize
    public int Compare(Brick a, Brick b)
    {
        if (a.boundMin.y < b.boundMin.y) return 1;
        else if (a.boundMin.y < b.boundMin.y) return -1;
        else
        {
            if (a.boundMin.x < b.boundMin.x) return 1;
            else if (a.boundMin.x < b.boundMin.x) return -1;
            else return 0;
        }
    }
    public static void CreateBrick(Vector2Int lowerBound, Vector2Int higherBound)
    {
        GameObject gb = Instantiate((GameObject)prefab.Result);
        gb.transform.parent = LevelLoader.currentSection.transform;
        Vector2Int dif = higherBound - lowerBound;
        gb.transform.localPosition = (lowerBound + ((Vector2)dif / 2f)) - new Vector2Int(0, LevelLoader.sectionNum * 8) ;
        Brick brick = gb.GetComponent<Brick>();
        brick.boundMin = lowerBound;
        brick.boundMax = higherBound;
    }
}
