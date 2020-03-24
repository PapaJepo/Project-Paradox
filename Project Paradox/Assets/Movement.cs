using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    //public Transform HoldPos;
    Vector2 i_movement;
    float moveSpeed = 7f;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";
    Vector3 m;
    Transform templook;
    //public Animator g_anim;
    public bool picked = false;


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


        /*if ((x < 0.15 && z < 0.15) && (x > -0.15 && z > -0.15))
        {
            // Debug.Log("NOTMOVING");
            //g_anim.GetComponent<Animator>().SetBool("isWalking", false);

            transform.rotation = templook.rotation;
            // Slerp(transform.rotation, Quaternion.LookRotation(m), 0.05f);

        }
        else
        {
            //g_anim.GetComponent<Animator>().SetBool("isWalking", true);
            //g_anim.GetComponent<Animator>().SetFloat("Move", x);
            //g_anim.GetComponent<Animator>().SetFloat("MoveV", z);

            Vector3 m = new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m), 0.05f);
            transform.Translate(m, Space.World);
            templook.rotation = transform.rotation;

        }
    */

        transform.position = x * (transform.forward * Time.deltaTime * moveSpeed);

    }

}
