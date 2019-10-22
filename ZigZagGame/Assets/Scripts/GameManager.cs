using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game state")]
    public int points = 0;
    public int tilesPassed = 0;
    public bool gameIsOn = true;

    [Header("Conditions")]
    public int pointEachTiles = 3;

    [Header("Game UI")]
    public GameObject panelStart;
    public GameObject panelRestart;
    public GameObject panelScore;
    public Text funnyText;

    [Header("Other")]
    public GameObject player;
    public PlayerMoveCore move;

    public Text ScoreTxt;

    public void AddPoints(int amount)
    {
        points += amount;
    }

    List<string> phrases;
    int i = 0;

    string urlChannelYouTube = "https://www.youtube.com/channel/UC1EFZ1b2qP5W4Qy8VeFb3Tw?view_as=subscriber";

    private void Start()
    {
        phrases = new List<string>();
        phrases.Add("Beat ur Grandma first!");
        phrases.Add("Don't u dare clickin' me!");
        phrases.Add("Stop it!");
        phrases.Add("I have the HIGH GROUND");
        phrases.Add("Don't even try it");
        phrases.Add("{Obi cuts his legs next moment}");
        phrases.Add("You were like son to me!");
        phrases.Add("You were ment to destroy the sith not to join them!");
        phrases.Add("Hello there!");
        phrases.Add("Okay, I'm not obi, I'm just a button, so stop it");
        phrases.Add("I'm out");
        phrases.Add("...");
        phrases.Add("...");
        phrases.Add("...");
        phrases.Add("...");
        phrases.Add("...");
        phrases.Add("...");
        phrases.Add("You're still here so push YouTube button and subscribe, push bell and like all videos. Also bring me a couple of subs. Thank you!");

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (!gameIsOn&&!panelRestart.activeSelf)
        {
            panelScore.SetActive(false);
            panelRestart.SetActive(true);
        }
        
        if(gameIsOn)
        {
            if (move != null)
            {
                if (!move.activeB)
                {
                    panelScore.SetActive(false);
                }
                else if (move.activeB && !gameIsOn)
                {
                    panelScore.SetActive(true);
                }
                else
                {
                    panelScore.SetActive(true);
                }
            }
        }

        CheckPoints();
    }

    void CheckPoints()
    {
        if (tilesPassed >= pointEachTiles)
        {
            tilesPassed = 0;
            points++;
        }

        ScoreTxt.text = "" + points;
        
        
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

    public void ChangeFunnyText()
    {
        funnyText.text = phrases[i];
        i++;
        if (i == phrases.Count) i--;
    }

    public void openYouTube()
    {
        Application.OpenURL(urlChannelYouTube);
    }
}
