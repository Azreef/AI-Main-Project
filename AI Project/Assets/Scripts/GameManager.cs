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

    void setScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    void setHealthBar()
    {
        newBar = (health/maxHealth);
        


        healthBar.fillAmount = newBar;

       /* healthBar.transform.localScale = new Vector3((float)newBar, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBar.transform.localPosition.Set(1, healthBar.transform.position.y, healthBar.transform.position.z);*/

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
        //Debug.Log(health);

    }

}
