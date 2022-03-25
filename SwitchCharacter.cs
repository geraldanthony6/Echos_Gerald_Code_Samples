using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]private Camera mainCharCam;
    [SerializeField]private CinemachineFreeLook vcam;
    [SerializeField]private Camera animalCam;
    [SerializeField]private GameObject mainChar;
    [SerializeField]private GameObject knight;
    [SerializeField]private GameObject mage;
    [SerializeField]private GameObject rogue;
    [SerializeField]private GameObject animal;

    [SerializeField] private GameObject knightSkeleton;
    
    [SerializeField] private GameObject mageSkeleton;
    
    [SerializeField] private GameObject rogueSkeleton;
    private GameObject currKnightSkeleton;
    private GameObject currMageSkeleton;
    private GameObject currRogueSkeleton;

    [SerializeField]private Vector3 mainCharCurPos;
    [SerializeField] private Vector3 kinghtSkeletonCurPos; 
    [SerializeField] private Vector3 mageSkeletonCurPos;
    [SerializeField] private Vector3 rogueSkeletonCurPos;
    [SerializeField] private Vector3 animalCurPos;
    [SerializeField] private Vector3 mageCurPos; 

    [SerializeField]private float distanceFromKnight;
    [SerializeField] private float distanceFromMage;
    [SerializeField] private float distanceFromRogue;
    
    private bool switchAvailable1 = true;
    private bool switchAvailable2 = true;
    private bool switchAvailable3 = true;
    private bool animalSwitch = true;
    void Start(){
        currKnightSkeleton = GameObject.FindGameObjectWithTag("KnightSkeleton");
        currMageSkeleton = GameObject.FindGameObjectWithTag("MageSkeleton");
        currRogueSkeleton = GameObject.FindGameObjectWithTag("RogueSkeleton");
    }
    // Update is called once per frame
    void Update()
    {
        mainCharCurPos = mainChar.transform.position;
        kinghtSkeletonCurPos = knight.transform.position;
        mageSkeletonCurPos = mage.transform.position;
        rogueSkeletonCurPos = rogue.transform.position;
        animalCurPos = animal.transform.position;
        mageCurPos = mage.transform.position;
        distanceFromKnight = Vector3.Distance(mainCharCurPos, kinghtSkeletonCurPos);
        distanceFromMage = Vector3.Distance(mainCharCurPos, mageSkeletonCurPos);
        distanceFromRogue = Vector3.Distance(mainCharCurPos, rogueSkeletonCurPos);
        KnightSwitch();
        MageSwitch();
        RogueSwitch();
        AnimalSwitch();
    }

    void KnightSwitch(){
        if(Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable1 == true && distanceFromKnight <= 2){
            vcam.LookAt = knight.transform;
            vcam.Follow = knight.transform;
            mainChar.gameObject.SetActive(false);
            currMageSkeleton.gameObject.SetActive(false);
            currRogueSkeleton.gameObject.SetActive(false);
            knight.gameObject.SetActive(true);
            switchAvailable1 = false;
            Destroy(currKnightSkeleton);
        } else if(Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable1 == false){
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currMageSkeleton.gameObject.SetActive(true);
            currRogueSkeleton.gameObject.SetActive(true);
            knight.gameObject.SetActive(false);
            switchAvailable1 = true;
            currKnightSkeleton = Instantiate(knightSkeleton, knight.transform.position, Quaternion.identity);
        }
    }

        void MageSwitch(){
        if(Input.GetKeyDown(KeyCode.Alpha2) && switchAvailable2 == true && distanceFromMage <= 2){
            vcam.LookAt = mage.transform;
            vcam.Follow = mage.transform;
            mainChar.gameObject.SetActive(false);
            currKnightSkeleton.gameObject.SetActive(false);
            currRogueSkeleton.gameObject.SetActive(false);
            mage.gameObject.SetActive(true);
            switchAvailable2 = false;
            Destroy(currMageSkeleton);
        } else if(Input.GetKeyDown(KeyCode.Alpha2) && switchAvailable2 == false){
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currKnightSkeleton.gameObject.SetActive(true);
            currRogueSkeleton.gameObject.SetActive(true);
            mage.gameObject.SetActive(false);
            switchAvailable2 = true;
            currMageSkeleton = Instantiate(mageSkeleton, mage.transform.position, Quaternion.identity);
        }
    }

        //animal switching ties the mages position to the mouse and vice versa
        void AnimalSwitch(){
            if(Input.GetKeyDown(KeyCode.E) && switchAvailable2 == false && animalSwitch == true){
            mage.gameObject.SetActive(false);
            mainCharCam.gameObject.SetActive(false);
            animal.gameObject.SetActive(true);
            animalCam.gameObject.SetActive(true);
            animal.transform.position = mageCurPos - new Vector3 (0, .8f, 0);
            animalSwitch = false;
            } else if(Input.GetKeyDown(KeyCode.E) && switchAvailable2 == false && animalSwitch == false){
            mage.gameObject.SetActive(true);
            mainCharCam.gameObject.SetActive(true);
            animal.gameObject.SetActive(false);
            animalCam.gameObject.SetActive(false);
            mage.transform.position = animalCurPos + new Vector3(0, .8f, 0);
            animalSwitch = true;
            }
        }

        void RogueSwitch(){
        if(Input.GetKeyDown(KeyCode.Alpha3) && switchAvailable3 == true && distanceFromRogue <= 2){
            vcam.LookAt = rogue.transform;
            vcam.Follow = rogue.transform;
            mainChar.gameObject.SetActive(false);
            currKnightSkeleton.gameObject.SetActive(false);
            currMageSkeleton.gameObject.SetActive(false);
            rogue.gameObject.SetActive(true);
            switchAvailable3 = false;
            Destroy(currRogueSkeleton);
        } else if(Input.GetKeyDown(KeyCode.Alpha3) && switchAvailable3 == false){
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currKnightSkeleton.gameObject.SetActive(true);
            currMageSkeleton.gameObject.SetActive(true);
            rogue.gameObject.SetActive(false);
            switchAvailable3 = true;
            currRogueSkeleton = Instantiate(rogueSkeleton, rogue.transform.position, Quaternion.identity);
        }
    }
}
