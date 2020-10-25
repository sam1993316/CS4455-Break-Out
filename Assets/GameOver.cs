using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI winLoseText;

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
        winLoseText.text = "You lose!";
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winLoseText.text = "You win!";
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }
}
