using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsScreenManager : MonoBehaviour
{

#if UNITY_STANDALONE
    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
#endif
}
