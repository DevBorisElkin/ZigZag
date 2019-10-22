using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDestroy : MonoBehaviour
{
    public float distanceToDestroy = 60f;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Ball");
    }

    
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.localPosition,player.transform.localPosition);
            if (distance >= distanceToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
