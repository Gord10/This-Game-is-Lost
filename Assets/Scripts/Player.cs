using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x = 4, y = 4;
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
