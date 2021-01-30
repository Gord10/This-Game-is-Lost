using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostGameManager : MonoBehaviour
{
    public int gameWidth = 17, gameLength = 12;
    public Text gameScreen;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        UpdateGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGame()
    {
        gameScreen.text = "";

        int j, i;
        for(j = gameLength -1; j >= 0; j--)
        {
            for(i = 0; i < gameWidth; i++)
            {
                if(i == player.x && j == player.y)
                {
                    gameScreen.text += "<color=cyan>@</color>";
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
