using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyUnitController : MonoBehaviour
{
    public PlayerCotroller playerCotroller;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(gameObject);
            playerCotroller.AddFriendlyUnit();
        }
    }
}
