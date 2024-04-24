using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentPortal;
    public AudioSource transformsound;
    public GameObject popup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentPortal != null)
            {
                transform.position = currentPortal.GetComponent<Portal>().GetDestination().position;
                transformsound.Play();
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Portal")
        {
            popup.SetActive(true);
            currentPortal = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        popup.SetActive(false);
        if (collision.gameObject.tag == "Portal")
        {
            if (collision.gameObject == currentPortal)
            {
                currentPortal = null;
            }
        }
    }
}
