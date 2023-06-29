using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] DataScriptableObject data;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject StageOverPanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI totalShotText;
    [SerializeField] TextMeshProUGUI bestShotText;

    void Start()
    {
       StageOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkGamePause();
        checkGameOver();

    }


    void checkGamePause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!PausePanel.activeSelf)
            {
                Pause();

            }
            else if (PausePanel.activeSelf)
            {
                Continue();

            }

        }
    }

    void checkGameOver()
    {
        if (data.getGameIsOver())
        {
            StageOverPanel.SetActive(true);
            totalShotText.text = "Total Shot: " + gameManager.getTotalScore().ToString();
            bestShotText.text = "Best Shot: " + data.getBestShot(data.getCurrentLevel());
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
