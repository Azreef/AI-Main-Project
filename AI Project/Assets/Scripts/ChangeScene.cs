using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    DataScriptableObject data;
    
    public void selectScene(int sceneID)
    {
        FindAnyObjectByType<SoundManager>().Play("menu1Sound");
        SceneManager.LoadSceneAsync(sceneID);
    }

    public void restartScene()
    {
        FindAnyObjectByType<SoundManager>().Play("menu1Sound");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        FindAnyObjectByType<SoundManager>().Play("menu1Sound");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
