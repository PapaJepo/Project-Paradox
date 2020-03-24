using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public Aiming mouselook;
    public AudioSource Breathing;


    private Rigidbody p_rb;
    private CharacterController _CharCont;

    public float speed = 4f;
    public float jumppower = 5f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        p_rb = GetComponent<Rigidbody>();
        _CharCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _CharCont.Move(move * speed * Time.deltaTime);


        if (x == 0 && z == 0 )
        {
           // StartCoroutine(Breath());
        }

        //if(Input.GetButton(""))
    }

    IEnumerator Breath()
    {
        Debug.Log("Start Wait");
        yield return new WaitForSeconds(5);
        Debug.Log("End Wait");
        Breathing.Play();
    }
}
