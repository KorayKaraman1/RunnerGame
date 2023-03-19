using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType { multiplyType,additionType}
public class GateController : MonoBehaviour
{
    public PlayerCotroller playerController;
    public GatesHolderController gatesHolderController;
    public TMPro.TextMeshProUGUI gateText;
    public int gateValue;
    public GateType gateType;
    bool hasGateUsed;
    
    void Start()
    {
        AddGateValueAndSymbol();


    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&& hasGateUsed==false)
        {
            hasGateUsed=true;
            playerController.SpawnPlayer(gateValue,gateType);
            gatesHolderController.CloseGate();
            Destroy(gameObject);
        }
    }
    public void AddGateValueAndSymbol()
    {
        switch (gateType)
        {
            case GateType.multiplyType:
                gateText.text= "x"+gateValue.ToString();
                break;
            case GateType.additionType:
                gateText.text= "+"+gateValue.ToString();
                break ;
            default:
                break;
        }
    }
}
