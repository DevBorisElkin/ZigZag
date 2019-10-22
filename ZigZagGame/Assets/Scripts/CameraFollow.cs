using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0,0,0);
    PlayerMoveCore playerMove;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        if (player == null)
        {
            player = GameObject.Find("Ball");
        }
        playerMove = player.GetComponent<PlayerMoveCore>();
    }
    
    void Update()
    {
        if (!gameManager.gameIsOn) return;
        if (player != null)
        {
            transform.position = new Vector3(player.transform.localPosition.x + offset.x, player.transform.localPosition.y + offset.y, player.transform.localPosition.z + offset.z);
        }
        
    }
}
