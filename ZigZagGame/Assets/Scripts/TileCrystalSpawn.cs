using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCrystalSpawn : MonoBehaviour
{
    public bool spawnEnabled = true;
    public bool wideTile_1 = false;
    public bool wideTile_2 = false;

    public GameObject crystalPrefab;
    public GameObject redCrystalPrefab;
    public GameObject goldenCrystalPrefab;
    public int spawnChance = 20;
    public List<GameObject> spawns = new List<GameObject>();

    [Header("Decorations")]
    public List<GameObject> decorPrefabs = new List<GameObject>();
    public List<GameObject> decorRandomRemovable = new List<GameObject>();
    public List<GameObject> addCrystalSpawns = new List<GameObject>();
    public int decorSpawnChance = 10;

    void Start()
    {
        if (spawnEnabled)
        {
            int a = Random.Range(1, 101);
            if (a <= spawnChance)
            {
                int currentSpawn = Random.Range(0, spawns.Count);
                int currentCrystal = Random.Range(0,201);
                GameObject chosenPrefab;
                if (currentCrystal <= 1)
                {
                    if (FindObjectOfType<GameManager>().GetComponent<GameManager>().points > 50)
                    {
                        chosenPrefab = goldenCrystalPrefab;
                    }
                    else
                    {
                        chosenPrefab = crystalPrefab;
                    }
                }
                else if (currentCrystal <= 15)
                {
                    if (FindObjectOfType<GameManager>().GetComponent<GameManager>().points > 120)
                    {
                        chosenPrefab = redCrystalPrefab;
                    }
                    else
                    {
                        chosenPrefab = crystalPrefab;
                    }
                }
                else
                {
                    chosenPrefab = crystalPrefab;
                }
                GameObject crystal = Instantiate(chosenPrefab, spawns[currentSpawn].transform.position, spawns[currentSpawn].transform.rotation);
                crystal.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }

        if (wideTile_1)
        {
            foreach(GameObject spawn in spawns)
            {
                int a = Random.Range(1, 101);
                if (a <= decorSpawnChance)
                {
                    GameObject obj = Instantiate(decorPrefabs[Random.Range(0, decorPrefabs.Count)], spawn.transform.position, spawn.transform.rotation);
                    GameObject parent = gameObject.transform.Find("TileBody").gameObject;
                    obj.transform.parent = parent.transform; 
                }
            }
            int rand = Random.Range(1,101);
            if (rand <= 7)
            {
                GameObject crystal = Instantiate(goldenCrystalPrefab, addCrystalSpawns[0].transform.position, addCrystalSpawns[0].transform.rotation);
                crystal.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
        if (wideTile_2)
        {
            foreach (GameObject obj in decorRandomRemovable)
            {
                int a = Random.Range(1, 101);
                if (a <= 55)
                {
                    int b = Random.Range(1, 101);
                    if (b < 75)
                    {
                        GameObject obj2 = Instantiate(decorPrefabs[Random.Range(0, decorPrefabs.Count)], obj.transform.position, obj.transform.rotation);
                        GameObject parent = gameObject.transform.Find("TileBody").gameObject;
                        obj2.transform.parent = parent.transform;
                    }
                    Destroy(obj);
                }
            }
            foreach (GameObject spawn in spawns)
            {
                int a = Random.Range(1, 101);
                if (a <= decorSpawnChance)
                {
                    int r = Random.Range(0, decorPrefabs.Count);
                    if(r == 14|| r == 13|| r == 11|| r == 10|| r == 9||r == 8)
                    {
                        int rand2 = Random.Range(1,101);
                        if (rand2 <= 70)
                        {
                            r = Random.Range(0, 6);
                        }
                    }
                    GameObject obj = Instantiate(decorPrefabs[r], spawn.transform.position, spawn.transform.rotation);
                    GameObject parent = gameObject.transform.Find("TileBody").gameObject;
                    obj.transform.parent = parent.transform;
                }
            }
            int rand = Random.Range(1, 101);
            if (rand <= 30)
            {
                GameObject crystal = Instantiate(goldenCrystalPrefab, addCrystalSpawns[0].transform.position, addCrystalSpawns[0].transform.rotation);
                crystal.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
    }

    
}
