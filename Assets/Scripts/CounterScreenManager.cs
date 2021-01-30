using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CounterScreenManager : MonoBehaviour
{
    public Text text;
    DateTime targetDate;
    bool isSuccess = false;

    private void Awake()
    {
        targetDate = new DateTime(2022, 1, 31, 20, 0, 0);
        InvokeRepeating("UpdateCounterText", 0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void UpdateCounterText()
    {
        if(isSuccess)
        {
            return;
        }

        TimeSpan timeSpan = targetDate - DateTime.Now;

        bool debugWin = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift);

        if(timeSpan.TotalMilliseconds < 0 || debugWin)
        {
            text.text = "Success! Thank you for your patience.\n\nThis time you did not lose the game. You found the game!\n\nPress any key to continue the game.";
            isSuccess = true;
            return;
        }


        text.text = "This game will be found at\n" + targetDate.ToLongDateString() + " " + targetDate.ToLongTimeString();
        text.text += "\n\nWhich means there are " + (int)timeSpan.TotalDays + " days, " + string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds) + " hours.";

        // (int)timeSpan.TotalDays + " days, " + timeSpan.Hours + ":" + timeSpan.Minutes + "." + timeSpan.Seconds + " hours left";
        text.text += "\n\nThis date is based on your computer's time.";
    }
}
