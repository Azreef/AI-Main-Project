using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="sceneInfo", menuName = "Data")]
public class DataScriptableObject : ScriptableObject
{
     private int[] _bestShot = { 0, 0, 0, 0, 0, 0, 0, 0 }; //Best Score

     private bool _gameIsOver;

     private int _currentLevel;

    private void Awake()
    {
        
    }

    //GETTER
    public int getBestShot(int level)
    {
        return _bestShot[level];
    }

    public bool getGameIsOver()
    {
        return _gameIsOver;
    }

    public int getCurrentLevel()
    {
        return _currentLevel;
    }

    

    //SETTER
    public void setBestShot(int level, int score)
    {
        _bestShot[level] = score;
    }

    public void setGameIsOver(bool status)
    {
        _gameIsOver = status;
    }

    public void setCurrentLevel(int level)
    {
        _currentLevel = level;
    }

}
