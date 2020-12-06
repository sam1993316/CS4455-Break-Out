using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneMenu : MonoBehaviour
{
    public string level;

    public void NewGame()
    {
        SceneManager.LoadScene(level);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
