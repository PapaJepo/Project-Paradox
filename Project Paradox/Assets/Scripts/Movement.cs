using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    //public Transform HoldPos;
    Vector2 i_movement;
    float moveSpeed = 7f;

    public string Horizontal = "Horizontal";
    public string Vertical = "Vertical";
    Vector3 m;
    Transform templook;
    //public Animator g_anim;
    public bool picked = false;

    public AudioSource Breathing;
    // Start is called before the first frame update
    void Start()
    {
        templook = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            float x = Input.GetAxis(Horizontal);
            float z = Input.GetAxis(Vertical);


        transform.position = x * (transform.forward * Time.deltaTime * moveSpeed);


    }

    IEnumerator Breath()
    {
        yield return new WaitForSeconds(5);
        Breathing.Play();
    }


}
