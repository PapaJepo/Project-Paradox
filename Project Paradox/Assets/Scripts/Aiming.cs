﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public Transform LookBehind;
    float xRot = 0f;
    public float yRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetButton("Fire4"))
        {

            transform.LookAt(LookBehind.position);
        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            yRot += mouseX;
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            playerBody.localRotation = Quaternion.Euler(0f, yRot, 0f);

        }
    }
}
