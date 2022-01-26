using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeath : MonoBehaviour {

    [SerializeField] GameObject Turret;
    [SerializeField] int health;
    int damage = -2;
    //private AudioSource audioSource;
    //private AudioClip enemyDeathSound;

    void Start()
    {
        //audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        //enemyDeathSound = GameObject.FindGameObjectWithTag("Audio").GetComponent<NewScene>().GetaClip(0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Missile")
        {
            Debug.Log("Hit");
            health = health + damage;
            
            if (health <= 0)
            {
                Destroy(Turret.gameObject);
            }
        }
    }
}
