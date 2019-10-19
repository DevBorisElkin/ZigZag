using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminate : MonoBehaviour
{
    public bool terminateAfterStart = false;
    public float terminationTime = 2f;
    public bool destroyParent = false;
    
    void Start()
    {
        if (terminateAfterStart) Invoke("TerminateIt",terminationTime);
    }

    public void TerminateIt()
    {
        if (!destroyParent)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
        
    }
}
