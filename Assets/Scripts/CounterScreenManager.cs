using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CounterScreenManager : MonoBehaviour
{
    public Text text;
    DateTime targetDate;
    bool isSuccessful = false;

    private void Awake()
    {
        targetDate = new DateTime(2022, 1, 31, 20, 0, 0);
        InvokeRepeating("UpdateCounter", 0, 1);
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

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            SetSuccess();
        }

        if(isSuccessful && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Lost Game");
        }
    }

    void SetSuccess()
    {
        isSuccessful = true;
        text.text = "Success! Thank you for your patience.\n\nThis time you did not lose the game. You found the game!\n\nPress SPACE to continue the game.";
        CancelInvoke();
    }

    void UpdateCounter()
    {
        TimeSpan timeSpan = targetDate - DateTime.Now.ToLocalTime();

        if(timeSpan.TotalMilliseconds < 0)
        {
            SetSuccess();
            return;
        }

        text.text = "Current time is: " + DateTime.Now.ToLocalTime().ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ".";

        text.text += "\n\nThis game will be found at\n" + targetDate.ToLongDateString() + " " + targetDate.ToLongTimeString() + ".";
        text.text += "\n\nWhich means there are " + (int)timeSpan.TotalDays + " days, " + string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds) + " hours.";

        if(Time.timeSinceLevelLoad > 60)
        {
            text.text += "\n\n<color=green>Hint: You can change your computer's date and time. Or press Left Shift + W for cheating.</color>";
        }
        else
        {
            text.text += "\n\nThis time span is based on your computer's time.";
        }

        
    }
}
