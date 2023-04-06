using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    
    // load game over when called
    public void loadGameOver()
    {
        StartCoroutine(WaitBeforeGO("GameOver", loadDelay));
    }
    
    IEnumerator WaitBeforeGO(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
