using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    [SerializeField] int currentlevel, currentScore, health = 5;

    [SerializeField] TextMeshProUGUI scoreText;

   
    void setScoreText()
    {
        scoreText.text = currentScore.ToString();
    }


    //SETTER
    public void reduceHealth()
    {
        health--;
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
