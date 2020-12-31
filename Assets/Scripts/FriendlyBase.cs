using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyBase : MonoBehaviour
{
    public int baseHealth = 10;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip bombClip;
    
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = baseHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(baseHealth <= 0)
        {
            print("game over.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            baseHealth--;
            GetComponent<AudioSource>().PlayOneShot(bombClip, 1f);
            healthText.text = baseHealth.ToString();
        }
    }
}
