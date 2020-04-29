using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraView : MonoBehaviour
{
    public AudioSource MusicStart;
    public AudioSource Breathing;

    public bool Chase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {

       // MusicStart.Play();
       // Breathing.Play();
    }

    private void OnBecameInvisible()
    {
    }
}
