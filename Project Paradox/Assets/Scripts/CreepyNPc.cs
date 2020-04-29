using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyNPc : MonoBehaviour
{
    public GameObject Head;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Head.transform.LookAt(Player.transform);
    }
}
