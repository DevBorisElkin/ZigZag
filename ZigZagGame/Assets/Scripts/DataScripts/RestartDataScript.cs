using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartDataScript : MonoBehaviour
{
    public Text scoreRecordPersonText;
    GameManager manager;
    List<FakePerson> people;
    void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        CheckFirstLaunch();
        InitList();

        FakePerson person = people[Random.Range(0, people.Count)];
        var sb = new System.Text.StringBuilder();
        sb.Append("You got " + manager.points + " points" + System.Environment.NewLine + "Your Record: " + PlayerPrefs.GetInt("high_score", 0) + " points" + System.Environment.NewLine + person.name + "'s record: " + person.score + " points");
        scoreRecordPersonText.text = sb.ToString();
    }

    
    void CheckFirstLaunch()
    {
        int a = PlayerPrefs.GetInt("first_launch",1);
        if (a == 1)
        {
            PlayerPrefs.SetInt("Bill Gates", Random.Range(100,300));
            PlayerPrefs.SetInt("Mike Tyson", Random.Range(30, 200));
            PlayerPrefs.SetInt("Paul Mccartney", Random.Range(140, 300));
            PlayerPrefs.SetInt("Donald Trump", Random.Range(500, 1000));
            PlayerPrefs.SetInt("Gandalph Grey", Random.Range(15, 50));
            PlayerPrefs.SetInt("Your Granny", Random.Range(400, 800));
            PlayerPrefs.SetInt("Boris Elkin", 610);
            PlayerPrefs.SetInt("Danil Mamaev", 86);

            PlayerPrefs.SetInt("first_launch", 0);
        }
    }

    void InitList()
    {
        people = new List<FakePerson>();
        people.Add(new FakePerson("Bill Gates",     PlayerPrefs.GetInt("Bill Gates", 0)));
        people.Add(new FakePerson("Mike Tyson",     PlayerPrefs.GetInt("Mike Tyson", 0)));
        people.Add(new FakePerson("Paul Mccartney", PlayerPrefs.GetInt("Paul Mccartney", 0)));
        people.Add(new FakePerson("Donald Trump",   PlayerPrefs.GetInt("Donald Trump", 0)));
        people.Add(new FakePerson("Gandalph Grey",   PlayerPrefs.GetInt("Gandalph Grey", 0)));
        people.Add(new FakePerson("Your Granny",    PlayerPrefs.GetInt("Your Granny", 0)));
        people.Add(new FakePerson("Boris Elkin",    PlayerPrefs.GetInt("Boris Elkin", 610)));
        people.Add(new FakePerson("Danil Mamaev",   PlayerPrefs.GetInt("Danil Mamaev", 86)));
    }

    void Update()
    {
        
    }

    class FakePerson
    {
        public string name;
        public int score;
        public FakePerson(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
