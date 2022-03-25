using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageCharacter : MonoBehaviour
{
    //Fire Spell Variables
    public Transform castPoint;
    [SerializeField]private GameObject fireBall;
    public float fireSpellCooldown = 0;

    //Animal Switch Variables
    // [SerializeField]private PlayerMovement mageMovement;
    // [SerializeField]private GameObject mage;
    // [SerializeField]private GameObject animal;
    // [SerializeField]private Camera magCam;
    // [SerializeField]private Camera animalCam;
    // private bool canSwitch = true;
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireSpell();
        if(fireSpellCooldown > 0){
            fireSpellCooldown -= Time.deltaTime;
        }
    }

    void fireSpell(){
        if(Input.GetKeyDown(KeyCode.Q) && fireSpellCooldown <= 0){
            Instantiate(fireBall, castPoint.position, Quaternion.identity);
            fireSpellCooldown = 4;
        }
    }

}
