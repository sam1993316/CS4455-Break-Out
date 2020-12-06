using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public Text winLoseText;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void LoseGame()
        {
            winLoseText.text = "Y  O  U    L O S E!";
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Time.timeScale = 0f;
            Cursor.visible = true;
        }

        public void WinGame()
        {
            winLoseText.text = "Y O U   W I N!";
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Time.timeScale = 0f;
            Cursor.visible = true;

        }
    }
