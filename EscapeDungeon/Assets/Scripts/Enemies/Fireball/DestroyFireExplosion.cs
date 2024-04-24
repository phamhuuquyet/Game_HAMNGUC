using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireExplosion : MonoBehaviour
{
    public float aliveTime;
    public AudioSource fireexplosion;
    void Start()
    {
        fireexplosion.Play();
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
