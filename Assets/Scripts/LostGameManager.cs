using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostGameManager : MonoBehaviour
{
    public int gameWidth = 17, gameLength = 12;
    public Text gameScreen, narrationText;

    public int wallMinX = 16, wallMaxX = 28;
    public int wallMinY = 3, wallMaxY = 9;

    public string[] narrationTexts;

    public enum State
    {
        NARRATION,
        INGAME
    }

    public State state = State.NARRATION;

    Player player;
    int narrationCounter = 0;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        narrationText.text = narrationTexts[0];

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.NARRATION)
        {
            if(Input.anyKeyDown)
            {
                narrationCounter++;

                if(narrationCounter == narrationTexts.Length)
                {
                    state = State.INGAME;
                }
                else
                {
                    narrationText.text = narrationTexts[narrationCounter];
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Congrats");
            }
        }
    }

    public bool IsMovementAllowed()
    {
        return state == State.INGAME;
    }

    bool IsPositionWall(int x, int y)
    {
        if (x >= wallMinX && x <= wallMaxX)
        {
            if (y == wallMinY || y == wallMaxY)
            {
                return true;
            }
        }
        if (y >= wallMinY && y <= wallMaxY)
        {
            if (x == wallMinX || x == wallMaxX)
            {
                return true;
            }
        }


        return false;
    }

    public void UpdateGame()
    {
        gameScreen.text = "";

        int y, x;
        for(y = gameLength -1; y >= 0; y--)
        {
            for(x = 0; x < gameWidth; x++)
            {
                if(x == player.x && y == player.y)
                {
                    gameScreen.text += "<color=cyan>@</color>";
                }
                else if(IsPositionWall(x, y))
                {
                    gameScreen.text += "O";
                }
                else
                {
                    gameScreen.text += " ";
                }

            }

            gameScreen.text += "\n";
        }
    }
}
