using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private GameObject mainMenu;
    private GameObject optionsMenu;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            Debug.LogError("CanvasGroup could not be found");

        mainMenu = GameObject.Find("Main Menu");
        if (mainMenu == null)
            Debug.LogError("Main Menu could not be found");

        optionsMenu = GameObject.Find("Options Menu");
        if (optionsMenu == null)
            Debug.LogError("Options Menu could not be found");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseMenuInteraction()
    {
        if (canvasGroup.interactable)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
            Time.timeScale = 1f;
        }
        else
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Time.timeScale = 0f;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }
}
