using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.reduceHealth();
    }

   
}
