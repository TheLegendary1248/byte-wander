using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, IComparer<Brick>
{
    public Collider2D col;
    int health;
    public Vector2Int boundMin; //Lower left corner of the brick
    public Vector2Int boundMax; //Upper right corner of the brick

    // Start is called before the first frame update
    void Start()
    {
        BrickManager.RegisterBrick(this);
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
    public static void CreateBrick()
    {

    }
}
