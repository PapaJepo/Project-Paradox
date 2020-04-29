using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public PlayerActions PlayerRef;
    public GameObject Head;
    public GameObject Player;
    public GameObject DefaultHeadPos;
    public Animator N_Anim;
    public float speed = 2f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;
    public bool PlayerClose;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWaypoint = 0;
        //PlayerRef.GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerClose == true)
        {
            N_Anim.SetBool("Walk", false);
            Head.transform.LookAt(Player.transform);
        }
        else
        {
            N_Anim.SetBool("Walk", true);
            Head.transform.LookAt(DefaultHeadPos.transform);
             transform.LookAt(Waypoints[CurrentWaypoint].position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
            UpdateWaypoints();
        }
    }

    void UpdateWaypoints()
    {
        if (Vector3.Distance(Waypoints[CurrentWaypoint].position, this.transform.position) < 2)
        {
            CurrentWaypoint = (CurrentWaypoint + 1) % Waypoints.Count;

        }
    }

 
}
