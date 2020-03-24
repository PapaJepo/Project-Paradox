using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public DialogueManager DialogueRef;

    public Animator Door;

    public GameObject TextPopup;
    public GameObject TextObject;

    public bool Talking;
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
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Door here");
            //if (Input.GetKeyDown(KeyCode.E))
            // {
            Door.SetBool("Open", true);
            // }
        }
        if (other.gameObject.CompareTag("NPC"))
        {
            TextPopup.SetActive(true);
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

                Debug.Log("Talk");
                Talking = true;
               
            }
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

    }
}
