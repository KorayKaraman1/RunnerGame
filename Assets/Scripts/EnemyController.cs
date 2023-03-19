using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject playerSpawnerGameObject;
    public EnemySpawnerController enemySpawner;
    private bool isEnemyAlive;
    public Animator animator;
    
    
    void Start()
    {
        isEnemyAlive = true;
    }

    
    void FixedUpdate()
    {
        if (enemySpawner.isEnemyAttacking==true)
        {
            animator.SetBool("eRunning",true);
            transform.position = Vector3.MoveTowards(transform.position, playerSpawnerGameObject.transform.position, Time.fixedDeltaTime * 6f); 
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player"&&isEnemyAlive==true)
        {
            isEnemyAlive=false;
            enemySpawner.EnemyAttackingPlayer(collision.gameObject,this.gameObject);
        }
    }
    
}
