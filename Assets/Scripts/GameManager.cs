using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game state")]
    public int points = 0;
    public bool gameIsOn = true;

    [Header("Game UI")]
    public GameObject panelStart;
    public GameObject panelRestart;
    public GameObject panelScore;
    public GameObject player;

    public Text ScoreTxt;

    public void AddPoints(int amount)
    {
        points += amount;
        ScoreTxt.text = "Score: " + points;
    }

    private void Update()
    {
        if (!gameIsOn&&panelScore.activeSelf)
        {
            panelScore.SetActive(false);
            panelRestart.SetActive(true);
        }
        
        if(gameIsOn&&!panelScore.activeSelf)
        {
            panelScore.SetActive(true);
        }
    }

    public void StartGame()
    {
        panelStart.SetActive(false);
        player.GetComponent<PlayerMoveCore>().activeB = true;

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
