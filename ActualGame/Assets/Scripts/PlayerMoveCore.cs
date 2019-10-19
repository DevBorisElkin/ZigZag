using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCore : MonoBehaviour
{
    bool onPlatform = true;
    float failTimer = 0f;
    float failCap = 0.05f;
    public bool activeB = false;

    public float fallGimmikMultiplier = 0.5f;

    [Range(0,1f)]
    public float moveSpeed = 2f;
    Rigidbody rb;

    float forceZ = 0f;
    float forceX = 0f;

    TileManager tileManager;

    GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceX = moveSpeed;
        tileManager = FindObjectOfType<TileManager>().GetComponent<TileManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
        if (!gameManager.gameIsOn) return;
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
                gameManager.gameIsOn = false;
                rb.isKinematic = false;
                rb.AddForce(new Vector3(forceX*fallGimmikMultiplier, 0, forceZ*fallGimmikMultiplier), ForceMode.VelocityChange);
                Invoke("Delete", 5f);
            }
        }
        else
        {
            failTimer = 0;
        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            onPlatform = false;
            tileManager.TerminateTile(other.gameObject);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tile")
        {
            onPlatform = true;
        }
    }
}
