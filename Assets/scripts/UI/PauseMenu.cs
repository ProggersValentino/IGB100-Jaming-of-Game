using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused; //checks to determine if game is paused
    public GameObject pauseMenUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    
    //resumes game from pause
    public void resume()
    {
        pauseMenUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    
    // pauses the game
    void pause()
    {
        pauseMenUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
}
