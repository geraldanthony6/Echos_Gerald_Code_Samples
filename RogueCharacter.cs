using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCharacter : MonoBehaviour
{
    //Initialize Variables
    [SerializeField]private PlayerMovement rogueMovement;
    [SerializeField]private ClimbingMovement climbMovement;
    [SerializeField]private Rigidbody rogueRb;
    [SerializeField]private Transform rogueCurPos;
    [SerializeField]private Transform dashLocation;
    [SerializeField]private float dashCoolDown = 0;
    private bool canDash = true;
    [SerializeField]private bool canClimb = false;

    // Update is called once per frame
    void Update()
    {
        //Store rogue position
        rogueCurPos.position = transform.position;

        Dash();

        //Cooldown for dash ability, reworking stuff so it doesn't work
        if(dashCoolDown > 0){
            dashCoolDown -= Time.deltaTime;
        }
        if(dashCoolDown <= 0){
            canDash = true;
        }

        Climb();
    }

    //Reworking
    void Dash(){
        if(Input.GetKeyDown(KeyCode.E) && dashCoolDown <= 0 && canDash == true){

            canDash = false;
            dashCoolDown = 10;
        }
    }

    //Enables climbing on key press
    void Climb(){
        if(Input.GetKeyDown(KeyCode.Q) && canClimb == true){
            rogueMovement.enabled = false;
            climbMovement.enabled = true;
            rogueRb.useGravity = false;
        } else if(canClimb == false){
            climbMovement.enabled =false;
            rogueMovement.enabled = true;
            rogueRb.useGravity = true;
        }
    }

    //Checks collisions
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("ClimbableWall")){
            canClimb = true;
        } 
    }

    //Checks triggers
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("TopOfClimbabaleWall")){
            canClimb = false;
        }
    }




}
