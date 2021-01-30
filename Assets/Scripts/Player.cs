using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x = 4, y = 4;
    public int selfMovementInterval = 3; //At this interval, the protagonist will move to the window without the player's input
    LostGameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<LostGameManager>();
        x = gm.gameWidth / 2;
        y = gm.gameLength / 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GoToTheWindow", 0, selfMovementInterval);
    }

    void GoToTheWindow()
    {
        if(!gm.IsMovementAllowed())
        {
            return;
        }

        if(y < gm.wallMaxY - 1)
        {
            y++;
            gm.UpdateGame();
        }
        else
        {
            if(x < gm.GetMiddleWallX())
            {
                x++;
                gm.UpdateGame();
            }
            else
            {
                x--;
                gm.UpdateGame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!gm.IsMovementAllowed())
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(y < gm.wallMaxY -1)
            {
                y++;
            }
            
            gm.UpdateGame();
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(y > gm.wallMinY + 1)
            {
                y--;
            }
            
            gm.UpdateGame();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(x > gm.wallMinX +1)
            {
                x--;
            }
            
            gm.UpdateGame();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (x < gm.wallMaxX - 1)
            {
                x++;
            }
            gm.UpdateGame();
        }
    }
}
