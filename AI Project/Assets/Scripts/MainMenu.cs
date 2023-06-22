using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
