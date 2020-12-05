using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scene m_Scene = SceneManager.GetActiveScene();
            string sceneName = m_Scene.name;
            if (sceneName.Equals("Level0"))
            {
                SceneManager.LoadScene("1rstLevel");
            } else if (sceneName.Equals("1rstLevel")) {
                SceneManager.LoadScene("Level2");
            }else 
            {
                TestControllerForThirdPersonCamera script = player.GetComponent<TestControllerForThirdPersonCamera>();
                script.WinGame();
            }
        }
    }
}
