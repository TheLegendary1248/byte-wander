using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TempFormat : BrickFormatter
{
    static int[] avoider = new int[42]; //HARDCODED, GET RID OF
    public static void Reset()
    {

    }
    
    public static void Load(int[] space)
    {
        /*
        for (int i = 0; i < 8; i++)
        {
            for (int k = 0; k < 42; k++)
            {
                if (FileWanderer.GetBytes(1)[0] > 100)
                {
                    Vector2Int vec = new Vector2Int(k - 21, i + LevelLoader.sectionNum );
                    Brick.CreateBrick(vec, vec);
                }
            }
        }*/
        for (int ypos = 0; ypos < space.Length; ypos++)
        {
            for (int m = 0; m < avoider.Length; m++) avoider[m] = avoider[m] - 1; //Reduce every value in the avoider by one
            int arr = space[ypos];
            int half = arr / 2;
            for (int xpos = 0; xpos < arr;)
            {
                //Get x and y scale of our brick from the byte
                int yspan = FileWanderer.GetBytes(1)[0];
                int xspan = yspan & 0b_0000_1111;   //Y will be the last four bits
                yspan >>= 4;                        //X will be the first four bits
                yspan /= 2;
                xspan /= 2;
                if (yspan == 0) //If the brick has an invalid y scale, skip along k by x + 1
                {
                    xpos += xspan + 1;
                }
                else
                {
                    int limit = Mathf.Min(xpos + xspan, 42);
                    //Check if we have space for the brick
                    for (int m = xpos; m < limit; m++) if (avoider[m] > 0) { goto failed_fit; }
                    //Update the avoider
                    if (yspan > 1) for (int m = xpos; m < limit; m++) avoider[m] = yspan;
                    Brick.CreateBrick(new Vector2Int(xpos - half, ypos + (LevelLoader.sectionNum * 8)), new Vector2Int((xpos + xspan) - half, ypos + yspan + (LevelLoader.sectionNum * 8)));
                }
                xpos += Mathf.Max(1,xspan);
                failed_fit:;
            }
        }    
    }
}
