using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool isDeath;
    public float maxHealth;
    float currentHealth;

    public AudioSource playerhitted;
    public Slider playerHealthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerhitted.Play();
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        isDeath = true;
        playerHealthSlider.value = 0;
        UIManager.Instance.txtGameOver.SetActive(true);
        gameObject.SetActive(false);
    }
}
