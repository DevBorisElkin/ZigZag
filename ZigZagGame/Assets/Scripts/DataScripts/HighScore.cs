using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("high_score",0);
        highScoreText.text = "Your High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
