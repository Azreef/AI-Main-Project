using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataMana : MonoBehaviour
{

    int[] totalScore;


    public int getScore(int level)
    {
        return totalScore[level]; 
    }
    
    public void setScore(int level,int score)
    {
        totalScore[level] = score;
    }
    
}
