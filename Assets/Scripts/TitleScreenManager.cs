﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return;
        }
#endif

        if (Input.anyKeyDown && Time.timeSinceLevelLoad > 0.2f)
        {
            SceneManager.LoadScene("Counter");
        }
    }
}
