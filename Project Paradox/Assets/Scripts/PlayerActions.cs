using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public DialogueManager DialogueRef;

    public List<Animator> Doors;
    public Animator AutoDoor;
    public GameObject TextPopup;
    public GameObject TextObject;

    public bool NPCBool = false;
    public bool Talking;
    public bool Key;
    public GameObject KeyText;

    public GameObject GasCan;
    public Transform HoldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Talking == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                DialogueRef.DisplayNextSentence();
            }
        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door") && Key == true)
        {
            Debug.Log("Door here");
            //if (Input.GetKeyDown(KeyCode.E))
            // {
            foreach (Animator door in Doors)
            {
                door.SetBool("Open", true);
            }
            // }
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            TextPopup.SetActive(true);
        }
        if(other.gameObject.CompareTag("AutoDoor"))
        {
            AutoDoor.SetBool("Open", true);
        }
        if(other.gameObject.CompareTag("Key"))
        {
            Key = true;
            KeyText.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("GasCan"))
        {
            other.gameObject.transform.parent = HoldPosition.transform;
            other.gameObject.transform.position = HoldPosition.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
           
            if (Input.GetButton("Fire1"))
            {
                TextPopup.SetActive(false);
                other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                TextObject.SetActive(true);

               
                Talking = true;
              
            }
        }
        if (other.gameObject.CompareTag("NPC_Manager"))
        {

            //if (Input.GetButton("Fire1"))
            //{
                NPCBool = true;
                other.gameObject.GetComponent<NPC>().PlayerClose = NPCBool;
            //}
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            
                TextPopup.SetActive(false);
            TextObject.SetActive(false);
            Talking = false;
        }
        if (other.gameObject.CompareTag("NPC_Manager"))
        {

            //if (Input.GetButton("Fire1"))
           // {
                NPCBool = false;
                other.gameObject.GetComponent<NPC>().PlayerClose = NPCBool;
           // }
        }
        if (other.gameObject.CompareTag("AutoDoor"))
        {
            AutoDoor.SetBool("Open", false);
        }
    }
}
