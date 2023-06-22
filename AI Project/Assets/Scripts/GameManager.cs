using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] float currentlevel, currentScore, health = 5f, maxHealth = 5f;

    [SerializeField] TextMeshProUGUI scoreText;

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

    void setScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    void setHealthBar()
    {
        newBar = (health/maxHealth);
        
        healthBar.fillAmount = newBar;

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
    }

}
