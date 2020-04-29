using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Event1")]
    public GameObject Event3;


    [Header("Event 3")]
    public GameObject BloodObjects;
    public GameObject DoorBlood;
    public GameObject Key;
    public GameObject NPCStore;


    [Header("Monster Event")]
    public GameObject Monster;
    public GameObject Monster2;
    public GameObject NPC;
    public GameObject NPC2;
    public GameObject EndEvent;

    public GameObject CreepyLook;
    public Animator CreepyNpc;

    [Header("End Event")]
    public GameObject EndScreen;

    public GameObject ClerkSFX;

    public GameObject CreepyNPC;
    public GameObject CreepyEvent;
    public GameObject DeadCreep;
    public GameObject NewBlood;

    public GameObject Clerkev1;
    public GameObject Clerkev2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndEvent"))
        {
            EndScreen.SetActive(true);
            Monster.SetActive(false);
            Monster2.SetActive(false);
        }

        if(other.gameObject.CompareTag("ClerkEvent"))
        {
            Clerkev2.SetActive(false);
            ClerkSFX.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("ClerkEvent2"))
        {
            Clerkev1.SetActive(false);
            ClerkSFX.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Event1"))
        {
            other.gameObject.SetActive(false);
            Event3.SetActive(true);
        }


        if(other.gameObject.CompareTag("Event3"))
        {
            BloodObjects.SetActive(true);
            DoorBlood.SetActive(true);
            Key.SetActive(true);
            NPCStore.SetActive(false);
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("MonsterEvent"))
        {
            NPC.SetActive(false);
            NPC2.SetActive(false);
            Monster.SetActive(true);
            Monster2.SetActive(true);
            EndEvent.SetActive(true);
            other.gameObject.SetActive(false);

            CreepyEvent.SetActive(true);
            CreepyLook.SetActive(true);
            CreepyNpc.SetBool("Change", true);
        }
        if(other.gameObject.CompareTag("CreepyEvent"))
        {
            CreepyNPC.SetActive(false);
            other.gameObject.SetActive(false);
            NewBlood.SetActive(true);
            DeadCreep.SetActive(true);
        }
       
       
    }
}
