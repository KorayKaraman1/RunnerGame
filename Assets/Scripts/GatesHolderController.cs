using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesHolderController : MonoBehaviour
{
    
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
    public void CloseGate()
    {
        for (int i = 0; i <transform.childCount; i++)
        {
            if (transform.GetChild(i)!=null)
            {
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
