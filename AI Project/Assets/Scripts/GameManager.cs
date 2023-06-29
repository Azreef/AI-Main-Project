using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] public DataScriptableObject data;
    [SerializeField] float health = 5f, maxHealth = 5f;
    [SerializeField] int currentScore, currentlevel;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image healthBar;

    

    float newBar;


    //SETTER
    public void reduceHealth()
    {
        health--;
        
        setHealthBar();
    }
    public void incrementScore()
    {
        currentScore++;
    }


    private void checkStageOver()
    {
        if(health <= 0)
        {
            int currentLevel = data.getCurrentLevel();

            //set New HighScore
            if (currentScore < data.getBestShot(currentLevel) || data.getBestShot(currentLevel) == 0)
            {
                data.setBestShot(currentLevel, currentScore);
            }

            data.setGameIsOver(true);
        }
    }


    void setScoreText()
    {
        scoreText.text = "Total Shots: " + currentScore.ToString();
    }

    void setHealthBar()
    {
        newBar = (health/maxHealth);
 
        healthBar.fillAmount = newBar;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        data.setCurrentLevel(currentlevel);
        levelText.text = "Level " + (currentlevel + 1).ToString();
        data.setGameIsOver(false);
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
        checkStageOver();

    }  
    
    public int getTotalScore()
    {
        return currentScore;
    }
}
