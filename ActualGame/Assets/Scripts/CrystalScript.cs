using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public GameObject pickedParticles;
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Instantiate(pickedParticles,transform.position, transform.rotation);
            if (manager != null) manager.AddPoints(1);
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
