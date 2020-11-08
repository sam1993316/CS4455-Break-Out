﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneMenu : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("1rstLevel");
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
