using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject player;
    PlayerMoveCore playerMove;
    public GameObject lastTile;

    public RuntimeAnimatorController tileAnimator;

    [Header("Tile spawn parameters")]
    public int trySpawnEach = 3;
    public int swapChance = 40;
    public float minimumDistance = 35f;
    bool spawnLocked = false;

    float spawnZ = 2f;
    float spawnX = 0;

    
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Ball");
        }
        playerMove = player.GetComponent<PlayerMoveCore>();
    }

    void Update()
    {
        if (player == null) return;
        if (Vector3.Distance(player.transform.localPosition, lastTile.transform.localPosition) < minimumDistance&&!spawnLocked)
        {
            SpawnTiles(10);
        }
    }

    void SpawnTiles(int amount)
    {
        GameObject tmpTile;
        spawnLocked = true;
        for(int i=0; i < amount; i++)
        {
            TrySwapDirection(i,trySpawnEach);
            tmpTile = Instantiate(tilePrefab);
            tmpTile.transform.localPosition = new Vector3(lastTile.transform.localPosition.x+spawnX, lastTile.transform.localPosition.y, lastTile.transform.localPosition.z+spawnZ);
            lastTile = tmpTile;
        }
        spawnLocked = false;
    }

    void TrySwapDirection(int index, int swapChanceEach)
    {
        swapChanceEach++;
        if (index % swapChanceEach != 0) return;

        int a = Random.Range(1,101);
        if (a <= swapChance)
        {
            if (spawnZ == 2)
            {
                spawnZ = 0;
                spawnX = 2f;
            }else if (spawnX == 2f)
            {
                spawnX = 0;
                spawnZ = 2f;
            }
        }
    }

    public void TerminateTile(GameObject tile)
    {
        Animator tileAnim = tile.AddComponent<Animator>();
        tileAnim.runtimeAnimatorController = tileAnimator;
        tileAnim.Play("Entry");
    }
}
