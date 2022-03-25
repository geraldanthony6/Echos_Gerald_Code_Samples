using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCharacter : MonoBehaviour
{
    [SerializeField] private NewPlayerMovement knightMovment;
    [SerializeField] private GameObject boulder;
    [SerializeField]private Transform stonePlacement;
    [SerializeField] private Transform characterShoulder;
    [SerializeField]private Vector3 curBoulderPos;
    private float distanceFromBoulder;
    private bool canPickUpBoulder = true;
    private bool boulderInHand = false;

    // Update is called once per frame
    void Update()
    {
        curBoulderPos = boulder.transform.position;
        distanceFromBoulder = Vector3.Distance(transform.position, curBoulderPos);
        PickUpBoulder();
        if(boulderInHand){
        boulder.transform.position = characterShoulder.position;
        
        }
    }

    void PickUpBoulder(){
        if(Input.GetKeyDown(KeyCode.E) && canPickUpBoulder == true && distanceFromBoulder <= 2){
            boulder.transform.position = characterShoulder.position;
            knightMovment.playerSpeed = 1.5f;
            boulderInHand = true;
            canPickUpBoulder = false;
        } else if(Input.GetKeyDown(KeyCode.E) && canPickUpBoulder == false && boulderInHand == true){
            boulder.transform.position = stonePlacement.position;
            knightMovment.playerSpeed = 3f;
            boulderInHand = false;
            canPickUpBoulder = true;
        }
    }
}
