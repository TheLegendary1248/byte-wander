using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is essentially a really scuffed TileMap, for it's own purposes
/// </summary>
public static class BrickManager
{
    //This is my problem to deal with later. Essentially I cache the "tiles" where bricks are
    static Dictionary<Vector2Int, Brick> map = new Dictionary<Vector2Int, Brick>();
    /// <summary>
    /// This function is called by bricks when they're instantiated. Ensures that a brick does not occupy the space of another, via obliteration
    /// </summary>
    /// <param name="brick"></param>
    public static void RegisterBrick(Brick brick)
    {
        return;
        //CHECK IF BRICK IS WITHIN PLAYING AREA
        if (brick.boundMax == brick.boundMin)//Avoid the unnecessary looping if it's just one unit in size
        {
            if (map.ContainsKey(brick.boundMin))
            {
                Object.Destroy(brick.gameObject);
            }
            else map.Add(brick.boundMin, brick);
        }
        else
        {
            int i = 0;
            int k = 0;
            int height = brick.boundMax.y - brick.boundMin.y;
            int width = brick.boundMax.x - brick.boundMin.x;
            bool failed = false;
            for ( ; i < height; i++) //Height
            {
                for ( ; k < width ; k++) //Width
                {
                    if (map.ContainsKey(brick.boundMin))
                    {
                        Object.Destroy(brick.gameObject);
                        
                           
                        failed = true;
                        goto failed; //Really, TRY TO STAB ME
                    }
                    else map.Add(brick.boundMin + new Vector2Int(k,i), brick);
                }
            }
            failed:
            //If registration failed, rewind and delete our entries
            if (failed) for (; i >= 0; i--) for (; k >= 0; k--) map.Remove(brick.boundMin + new Vector2Int(k, i));
        }
    }
    /// <summary>
    /// Internally deletes a brick
    /// </summary>
    /// <param name="brick">The brick to move</param>
    public static void DeleteBrick(Brick brick)
    {

    }
    /// <summary>
    /// Internally moves a brick by translation. Does not check if there's a brick inbetween source and translation
    /// </summary>
    /// <param name="brick">The brick to move</param>
    /// <param name="translation">The new location of the brick relative to it's current internal location</param>
    /// <param name="hit">Returns any bricks that obstruct the new location</param>
    /// <returns>Returns true if the brick could be moved, otherwise false</returns>
    public static bool MoveBrick(Brick brick, Vector2Int translation, out Brick[] hit)
    {
        hit = null;
        return true;
    }
}