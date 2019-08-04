using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
  
    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
       
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().resetScore();   // because we only have 3 scenes, the Index stops at 2. So, we specify that once
    }                                               // the player reaches the last Index(the Play Again scene), it will always return
                                                    // them to the start scene. 
    public void QuitGame()
    {
        
        Application.Quit();
    }

}    



