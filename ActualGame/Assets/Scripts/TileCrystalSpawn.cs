using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCrystalSpawn : MonoBehaviour
{
    public bool spawnEnabled = true;
    public GameObject crystalPrefab;
    public List<GameObject> spawns = new List<GameObject>();
    void Start()
    {
        if (spawnEnabled)
        {
            int a = Random.Range(1, 101);
            if (a <= 20)
            {
                int currentSpawn = Random.Range(0, spawns.Count);
                GameObject crystal = Instantiate(crystalPrefab, spawns[currentSpawn].transform.position, spawns[currentSpawn].transform.rotation);
                crystal.transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
    }

    
}
