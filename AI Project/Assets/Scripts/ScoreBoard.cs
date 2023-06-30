using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] score;
    [SerializeField] DataScriptableObject data;

    private void Awake()
    {
        setScoreBoard();
        data.SetDirty();
    }

    public void resetScore()
    {
        for (int i = 0; i < 8; i++)
        {
            data.setBestShot(i, 0);
        }
        setScoreBoard();
    }

    public void setScoreBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            if (data.getBestShot(i) != 0)
            {
                score[i].text = "Best Shot: " + data.getBestShot(i).ToString();
            }
            else
            {
                score[i].text = "Best Shot: None";
            }

        }
    }
}
