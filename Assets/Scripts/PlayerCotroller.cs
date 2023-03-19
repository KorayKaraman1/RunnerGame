using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    [Header ("Player Movement Settings")]
    [Range(3f,7f)]public float playerForwardSpeed;
    public float playerHorizontalSpeed;
    private float horizontalValue;
    private float newXposition;
    public float horizontalLimitValue;
    public bool isPlayerMoved;

    [Header("Player Spawner Settings")]
    public GameObject playerGameObject;
    public List<GameObject> playerList;

    [Header("Game Sound Settings")]
    public LevelController levelController;
    public AudioSource audioSource,gameAudioSource;
    public AudioClip gameOverClip,victoryClip,spawnClip,destroyClip;
    




    void Start()
    {
        isPlayerMoved = false;
        
    }

    
    void Update()
    {
        PlayerMovement();
        AllPlayersKill();
    }
    public void PlayerMovement()
    {

        float touchX = 0;
        if (isPlayerMoved==false)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + playerForwardSpeed * Time.deltaTime);
        newXposition =transform.position.x+horizontalValue*(playerHorizontalSpeed*Time.deltaTime);
        newXposition = Mathf.Clamp(newXposition, -horizontalLimitValue, horizontalLimitValue);
        transform.position=new Vector3(newXposition, transform.position.y, transform.position.z);

    }
    public void SpawnPlayer(int gateValue,GateType gateType)
    {
        audioSource.PlayOneShot(spawnClip);
        if(gateType==GateType.additionType)
        {
            for (int i = 0; i < gateValue; i++)
            {
                GameObject newPlayerGameObject = Instantiate(playerGameObject, GetPlayerPosition(), Quaternion.identity, transform);
                playerList.Add(newPlayerGameObject);
            }
        }else if(gateType==GateType.multiplyType)
        {
            int newGateValue = (playerList.Count * gateValue)-playerList.Count;
            gateValue = newGateValue;
            for (int i = 0; i < gateValue; i++)
            {
                GameObject newGameObject = Instantiate(playerGameObject, GetPlayerPosition(), Quaternion.identity, transform);
                playerList.Add(newGameObject);
            }
        }

    }
    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere *0.1f;
        Vector3 newPos = transform.position + position;
        return newPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag=="finishLine")
        {
            isPlayerMoved = false;
            audioSource.PlayOneShot(victoryClip);
            levelController.gameMenu.SetActive(false);
            levelController.NextLevelMenu.SetActive(true);
          
        }else if(other.tag=="finishline2")
        {
            isPlayerMoved = false;
            audioSource.PlayOneShot(victoryClip);
            levelController.gameMenu.SetActive(false);
            levelController.finishMenu.SetActive(true);

        }
    }
    public void PlayerKill(GameObject playerGameObject)
    {
       playerList.Remove(playerGameObject);
       Destroy(playerGameObject);
        audioSource.PlayOneShot(destroyClip);
        
    }
    public void AllPlayersKill()
    {
        
        if (playerList.Count<=0)
        {
            isPlayerMoved=false;
            levelController.gameOverMenu.SetActive(true);
            levelController.gameMenu.SetActive(false);
            gameAudioSource.Stop();
            audioSource.PlayOneShot(gameOverClip,0.1f);
            
        }
        
    }
    public void AddFriendlyUnit()
    {
        audioSource.PlayOneShot(spawnClip);
        for (int i = 0; i <1; i++)
        {
            GameObject newGameObject = GameObject.Instantiate(playerGameObject, GetPlayerPosition(), Quaternion.identity, transform);
            playerList.Add(newGameObject);
        }
        
    }


}
