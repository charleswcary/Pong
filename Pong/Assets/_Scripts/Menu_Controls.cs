using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Controls : MonoBehaviour {

    public GameObject pauseMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.activeSelf)
            {
                EndPause();
            }
            else
            {
                StartPause();
            }
        }
    }

    public void StartPause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void EndPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
