using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCore : MonoBehaviour
{
    bool onPlatform = true;
    float failTimer = 0f;
    float failCap = 0.05f;
    public bool activeB = false;

    public GameObject particlesExplode;

    public float fallGimmikMultiplier = 0.5f;

    [Range(0,1f)]
    public float moveSpeed = 2f;
    Rigidbody rb;

    float forceZ = 0f;
    float forceX = 0f;

    TileManager tileManager;

    GameManager gameManager;
    AudioManager audio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceZ = moveSpeed;
        tileManager = FindObjectOfType<TileManager>().GetComponent<TileManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audio = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate()
    {
        if(gameManager.gameIsOn&&activeB)
        transform.Translate(new Vector3(forceX, 0, forceZ));

        CheckGameOver();
    }

    private void ChangeDirection()
    {
        if (!gameManager.gameIsOn||!activeB) return;
        
        rb.velocity = new Vector3(0, 0, 0);

        if (forceX > 0)
        {
            forceX = 0;
            forceZ = moveSpeed;
        }
        else if(forceZ >0)
        {
            forceZ = 0;
            forceX = moveSpeed;
        }
    }

    void CheckGameOver()
    {
        if (!onPlatform&& gameManager.gameIsOn)
        {
            failTimer += Time.deltaTime;
            if (failTimer >= failCap)
            {
                int highScore = PlayerPrefs.GetInt("high_score",0);
                if (gameManager.points > highScore)
                {
                    PlayerPrefs.SetInt("high_score", gameManager.points);
                }

                gameManager.gameIsOn = false;
                rb.isKinematic = false;
                rb.AddForce(new Vector3(forceX*fallGimmikMultiplier, 0, forceZ*fallGimmikMultiplier), ForceMode.VelocityChange);
                audio.makeLoseSound();
                Invoke("Delete", 2f);
            }
        }
        else
        {
            failTimer = 0;
        }
    }

    void Delete()
    {
        Instantiate(particlesExplode, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            onPlatform = false;
            tileManager.TerminateTile(other.gameObject);
            gameManager.tilesPassed++;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tile")
        {
            onPlatform = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            gameManager.gameIsOn = false;
            rb.isKinematic = false;
            audio.makeCrystalSound();
            Invoke("Delete", 2f);
        }
    }
}
