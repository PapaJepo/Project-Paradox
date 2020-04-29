using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class Monster : MonoBehaviour
{
    private enum NPCState { CHASE,PATROL,IDLE,SEARCH};
    private NPCState z_NPCState;

    public PostProcessVolume PP;
    public GameObject Player;
    public float speed = 2f;
    private NavMeshAgent z_navMeshAgent;

    private Animator m_Anim;

    public GameObject BreathSFX;
    public GameObject StingSFX;
    public GameObject EndScreen;

    public float fov = 110f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;

    public float DetectionRadius = 10f;

    private bool Searching;
    private Vector3 LastPlayerSighting;

    Vignette vignette = null;
    // Start is called before the first frame update
    void Start()
    {
        PP.profile.TryGetSettings(out vignette);
        m_Anim = GetComponent<Animator>();
        z_NPCState = NPCState.IDLE;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (z_NPCState)
        {
            case NPCState.IDLE:
                Idle();
                break;
            case NPCState.CHASE:
                Chase();
                break;
            case NPCState.PATROL:
                Patrol();
                break;
            case NPCState.SEARCH:
                Search();
                break;

            default:
                break;
        }

        //Vector3 direction = this.transform.position - Player.transform.position;
        //Debug.DrawLine(transform.position, Player.transform.position);
        //
        //if (Vector3.Distance(Player.transform.position,this.transform.position)<10)
        // {
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);
        //transform.LookAt(Player.transform.position);
        // Vector3 direction = Player.transform.position - transform.position;
        Detection();

        if(Waypoints.Count == 0)
        {
            z_NPCState = NPCState.CHASE;
            Detection();
        }
          
       // }
       // else
       // {
          //  BreathSFX.SetActive(false);
          //  z_NPCState = NPCState.PATROL;
        //}


        if(Vector3.Distance(Player.transform.position, this.transform.position) < 1)
        {
            Debug.Log("Death");
            EndScreen.SetActive(true);
        }

    
    }

    void Detection()
    {
        Collider[] PlayerCollider = Physics.OverlapSphere(this.transform.position, DetectionRadius);

        foreach(Collider Object in PlayerCollider)
        {
            if(Object.gameObject.tag == "Player")
            {
                Vector3 targetDirection = (Object.gameObject.transform.position - this.transform.position).normalized;
                Ray rayToTarget = new Ray(this.transform.position, targetDirection);
                RaycastHit hit;
                if(Physics.Raycast(rayToTarget, out hit, DetectionRadius))
                {
                    if(hit.collider.gameObject.tag == "Player")
                    {
                        //Debug.DrawLine(this.gameObject.transform.position, hit.collider.gameObject.transform.position, Color.red);
                        
                        vignette.intensity.value  = Random.Range(0.3f, 0.58f);
                        m_Anim.SetBool("Patrol", false);
                        z_NPCState = NPCState.CHASE;
                        LastPlayerSighting = hit.collider.gameObject.transform.position;
                        Searching = false;
                    }
                    else if(Searching == false && hit.collider.gameObject.tag != "Player")
                    {

                        BreathSFX.SetActive(false);

                        //StartCoroutine("WaitSearch");

                        z_navMeshAgent.SetDestination(LastPlayerSighting);
                        if (Vector3.Distance(LastPlayerSighting, this.transform.position) < 2)
                            {
                            //z_navMeshAgent.s
                            z_NPCState = NPCState.IDLE;
                            Searching = true;
                        }
                        //z_NPCState = NPCState.SEARCH;
                    }
                }
            }
        }
    }


    void Search()
    {
        
        z_navMeshAgent.SetDestination(LastPlayerSighting);
        //if(Vector3.Distance(LastPlayerSighting, this.transform.position)<2)
        //{
            
            z_NPCState = NPCState.PATROL;
      //  }
    }

    void Idle()
    {
        Debug.Log("Idle");
        m_Anim.SetBool("Patrol", false);
        m_Anim.SetBool("Walk", false);
        StartCoroutine("WaitIdle");
    }

    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(3f);
        z_NPCState = NPCState.PATROL;
    }

    void Chase()
    {
        Debug.Log("Chase");
        StingSFX.SetActive(true);
        BreathSFX.SetActive(true);
        m_Anim.SetBool("Walk", true);
        z_navMeshAgent.SetDestination(Player.transform.position);
    }

    void Patrol()
    {
        Debug.Log("Patrol");
        m_Anim.SetBool("Patrol", true);
        transform.LookAt(Waypoints[CurrentWaypoint].position);
        //transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
        z_navMeshAgent.SetDestination(Waypoints[CurrentWaypoint].position);

        if (Vector3.Distance(Waypoints[CurrentWaypoint].position, this.transform.position) < 2)
        {
            CurrentWaypoint = (CurrentWaypoint + 1) % Waypoints.Count;
            z_NPCState = NPCState.IDLE;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, Time.deltaTime * speed);
        }
    }
}
