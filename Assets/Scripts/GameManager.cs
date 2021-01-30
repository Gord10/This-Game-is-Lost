using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tile
{
    EMPTY,
    FOOD
}

public class GameManager : MonoBehaviour
{
    public Tile[,] tiles;
    public int gameWidth = 17, gameLength = 10;
    public Text gameScreen;

    Food food;

    private void Awake()
    {
        tiles = new Tile[gameWidth, gameLength];
        food = FindObjectOfType<Food>();

        int i, j;
        for(i = 0; i < gameWidth; i++)
        {
            for(j = 0; j < gameLength; j++)
            {
                tiles[i, j] = Tile.EMPTY;
            }
        }

        tiles[2, 4] = Tile.FOOD;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateGame", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGame()
    {
        food.UpdatePosition();

        gameScreen.text = "";

        int i, j;
        for (i = 0; i < gameLength; i++)
        {
            for (j = 0; j < gameWidth; j++)
            {
                Tile tile = tiles[j, i];
                switch(tile)
                {
                    case Tile.EMPTY:
                        gameScreen.text += " ";
                        break;

                    case Tile.FOOD:
                        gameScreen.text += "*";
                        break;
                }
            }
        }
    }
}
