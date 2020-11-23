using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel()
    {
        Debug.Log("restarting level...");
        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;
        SceneManager.LoadScene(sceneName);
    }
}
