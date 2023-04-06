using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    
    //goes to main game and starts it
    public void playGame()
    {
        // int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1; //calculation for next scene 
        SceneManager.LoadScene("MainGame");
    }
    
    //goes to tutorial and plays it
    public void learnGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 2; // calculation for next scene
        SceneManager.LoadScene(sceneIndex);
    }
    
    //quits the application 
    public void quitGame()
    {
        Debug.Log("raged quit haha"); //checking to see if works 
        Application.Quit();
    }
    
    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadTut()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadWin()
    {
        SceneManager.LoadScene("winScreen");
    }
    
  
}
