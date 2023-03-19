using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public PlayerCotroller playerCotroller;
    public GameObject playerSpawnerGameObject;
    public GameObject enemyGameObject;
    public int enemyCount;
    public List<GameObject> enemyList;
    public bool isEnemyAttacking;
    void Start()
    {

        SpawnEnemy();
    }

  
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = GameObject.Instantiate(enemyGameObject, GetEnemyPosition(), Quaternion.Euler(0,180,0), transform);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.playerSpawnerGameObject = playerSpawnerGameObject;
            enemyController.enemySpawner = this;
            enemyList.Add(enemy);
        }
        
    }
    public Vector3 GetEnemyPosition()
    {
        Vector3 position = Random.insideUnitSphere * 1f;
        Vector3 newPosisiton = transform.position + position;
        return newPosisiton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            LookPlayer(other.gameObject);
            isEnemyAttacking = true;

        }
    }
    public void LookPlayer(GameObject target)
    {
        Vector3 dir = transform.position - target.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        lookRotation.x = 0;
        lookRotation.z = 0;
        transform.rotation = lookRotation;
    }
    public void EnemyAttackingPlayer(GameObject player,GameObject enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy);
        playerCotroller.PlayerKill(player);
    }
   
}
