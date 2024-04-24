using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public bool isRun;
    public static PlayerController instance;

    public PlayerHealth player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(player.isDeath && !isRun)
        {
            isRun = true;
            StartCoroutine(DelayLoadScene());
        }
    }



    public IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(2f);


        SceneManager.LoadScene(0);
    }
}
