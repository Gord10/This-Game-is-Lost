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
        IN_GAME,
        GAME_OVER
    }

    public State state = State.NARRATION;

    Player player;
    int narrationCounter = 0;
    bool isShowingGameOverScreen = false;

    static bool didWeShowNarration = false;
    float timeWhenGameWasOver = 0;


    private void Awake()
    {
        player = FindObjectOfType<Player>();

#if !UNITY_EDITOR
        state = State.NARRATION;
#endif

        if(didWeShowNarration)
        {
            state = State.IN_GAME;
        }

        if(state == State.NARRATION)
        {
            narrationText.text = narrationTexts[0];
            didWeShowNarration = true;
        }
        else
        {
            narrationText.text = narrationTexts[narrationTexts.Length - 1];
        }
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
                    state = State.IN_GAME;
                }
                else
                {
                    narrationText.text = narrationTexts[narrationCounter];
                }
            }
        }
        else if(state == State.IN_GAME)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Congrats");
            }
        }
        else if(state == State.GAME_OVER)
        {
            if(isShowingGameOverScreen && Input.anyKeyDown && Time.timeSinceLevelLoad - timeWhenGameWasOver > 0.2f)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    public bool IsMovementAllowed()
    {
        return state == State.IN_GAME;
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

    public int GetMiddleWallX()
    {
        return (wallMinX + wallMaxX) / 2;
    }

    bool IsPositionWindow(int x, int y)
    {
        if(y == wallMaxY)
        {
            int middleWallX = GetMiddleWallX(); 
            int differenceBetweenWallMiddleX = Mathf.Abs(middleWallX - x);

            return differenceBetweenWallMiddleX < 2;
        }

        return false;
    }

    void ShowGameOverScreen()
    {
        gameScreen.text = "<color=red>TRY AGAIN</color>";
        gameScreen.alignment = TextAnchor.MiddleCenter;
        narrationText.enabled = false;
        isShowingGameOverScreen = true;
        timeWhenGameWasOver = Time.timeSinceLevelLoad;
    }

    public void UpdateGame()
    {
        gameScreen.text = "";

        if(IsPositionWindow(player.x, player.y + 1))
        {
            state = State.GAME_OVER;
            Invoke("ShowGameOverScreen", 0.2f);
            //return;
        }

        int y, x;
        for(y = gameLength -1; y >= 0; y--)
        {
            for(x = 0; x < gameWidth; x++)
            {
                if(x == player.x && y == player.y)
                {
                    gameScreen.text += "<color=cyan>@</color>";
                }
                else if(IsPositionWindow(x, y))
                {
                    gameScreen.text += "<color=red>0</color>";
                }

                else if(IsPositionWall(x, y))
                {
                    gameScreen.text += "#";
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
