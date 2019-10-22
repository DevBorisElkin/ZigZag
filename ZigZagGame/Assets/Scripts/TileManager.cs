using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject tilePrefab;

    public GameObject wideTilePrefab_1, wideTilePrefab_2;
    [Header("_____")]

    public GameObject player;
    PlayerMoveCore playerMove;
    public GameObject lastTile;

    public RuntimeAnimatorController tileAnimator;

    [Header("Tile spawn parameters")]
    public int trySpawnEach = 3;
    public int swapChance = 40;
    public float minimumDistance = 35f;
    bool spawnLocked = false;
    int turnBlock = 0;

    float spawnZ = 2f;
    float spawnX = 0;

    bool oneLittleBigAdjusted = false;


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
        if (player == null||lastTile==null) return;
        if (Vector3.Distance(player.transform.localPosition, lastTile.transform.localPosition) < minimumDistance&&!spawnLocked)
        {
            PreSpawn();
        }
    }

    void PreSpawn()
    {
        int a = Random.Range(1, 105);
        if (a <= 8)//8
        {
            turnBlock = 5;
            SpawnTiles(5);
            SpawnWideTiles(Random.Range(6, 10));
        }
        else
        {
            SpawnTiles(15);
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

            float additionalM = 1;

            tmpTile.transform.localPosition = new Vector3(lastTile.transform.localPosition.x+(spawnX*additionalM), lastTile.transform.localPosition.y, lastTile.transform.localPosition.z+(spawnZ * additionalM));
            lastTile = tmpTile;
        }
        spawnLocked = false;
    }

    void SpawnWideTiles(int amount)
    {
        spawnLocked = true;
        GameObject tmpTile;
        GameObject currentPrefab;
        float tile_widthM = 1;
        int a = Random.Range(1, 101);
        if (a <= 20)
        {
            currentPrefab = wideTilePrefab_2;
            tile_widthM = 4f;
            if (amount > 7) amount -= 4;
        }
        else
        {
            currentPrefab = wideTilePrefab_1;
        }
        for (int i = 0; i < amount; i++)
        {
            tmpTile = Instantiate(currentPrefab);
            if (i == 0)
            {
                tmpTile.transform.localPosition = new Vector3(lastTile.transform.localPosition.x + (spawnX), lastTile.transform.localPosition.y, lastTile.transform.localPosition.z + (spawnZ));
            }
            else if (i + 1 == amount)
            {
                tmpTile.transform.localPosition = new Vector3(lastTile.transform.localPosition.x + (spawnX * tile_widthM), lastTile.transform.localPosition.y, lastTile.transform.localPosition.z + (spawnZ * tile_widthM));
            }
            else
            {
                tmpTile.transform.localPosition = new Vector3(lastTile.transform.localPosition.x + (spawnX * tile_widthM), lastTile.transform.localPosition.y, lastTile.transform.localPosition.z + (spawnZ * tile_widthM));
            }
            
            if (spawnX > 0)
            {
                tmpTile.transform.Rotate(new Vector3(0,90,0));
            }
            lastTile = tmpTile;
        }
        turnBlock = 5;
        spawnLocked = false;
    }

    void TrySwapDirection(int index, int swapChanceEach)
    {
        if (turnBlock > 0)
        {
            turnBlock--;
            return;
        }
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
