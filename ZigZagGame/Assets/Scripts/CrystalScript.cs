using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public GameObject pickedParticles;
    GameManager manager;
    public int crystalPickGives = 2;
    AudioManager audio;
    void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audio = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Instantiate(pickedParticles,transform.position, transform.rotation);
            if (manager != null) manager.AddPoints(crystalPickGives);
            audio.makeCrystalSound();
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
