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
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            y++;
            gm.UpdateGame();
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            y--;
            gm.UpdateGame();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x--;
            gm.UpdateGame();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            x++;
            gm.UpdateGame();
        }

    }
}
