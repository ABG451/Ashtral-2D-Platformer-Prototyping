using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [SerializeField] Transform bulSpawn;

    [SerializeField] Rigidbody2D eProjectile;//, eHardProjectile, tProjectile;

    [SerializeField] float projSpeed, hprojSpeed, shootRate, spwnSpoint, direction;

    float shootTimer;

    [SerializeField] bool beginShoot, hardTurret, tricksterTurret;

    [SerializeField] GameObject turret;

	// Use this for initialization
	void Start () {
        beginShoot = false;
        shootTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        direction = turret.GetComponent<Transform>().rotation.eulerAngles.x;

        /*if (tricksterTurret)
        {
            turType.GetComponent<Renderer>().material.color = Color.green;
        }

        if (!tricksterTurret)
        {
            if (hardTurret == true)
            {
                turType.GetComponent<Renderer>().material.color = Color.red;
            }

            else if (!hardTurret)
            {
                turType.GetComponent<Renderer>().material.color = Color.blue;
            }
        }*/

        if (beginShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootRate)
            {
                /*if (tricksterTurret)
                {
                    Rigidbody2D tProjInstance;
                    tProjInstance = Instantiate(tProjectile, bulSpawn.position, bulSpawn.rotation);
					if (direction == 0.0f) //|| direction >= -360.0f && direction <= -270.1f)
                    {
                        tProjInstance.AddForce(bulSpawn.forward * projSpeed);
                        shootTimer = 0.0f;
                    }

                    if (direction == 180.0f) //|| direction >= -180.0f && direction <= -90.1f)
                    {
                        tProjInstance.AddForce(bulSpawn.forward * -projSpeed);
                        shootTimer = 0.0f;
                    }
                }*/

                if (!tricksterTurret)
                {
                    if (!hardTurret)
                    {
                        Rigidbody2D eProjInstance;
                        eProjInstance = Instantiate(eProjectile, bulSpawn.position, bulSpawn.rotation);
                        if (direction == 0.0f)
                        {
                            eProjInstance.AddForce(bulSpawn.right * -projSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 90.0f)
                        {
                            eProjInstance.AddForce(bulSpawn.up * -projSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 180.0f)
                        {
                            eProjInstance.AddForce(bulSpawn.right * projSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 270.0f)
                        {
                            eProjInstance.AddForce(bulSpawn.up * projSpeed);
                            shootTimer = 0.0f;
                        }
                    }

                    /*if (hardTurret)
                    {
                        Rigidbody2D eHProjInstance;
                        eHProjInstance = Instantiate(eHardProjectile, bulSpawn.position, bulSpawn.rotation);
                        if (direction >= 0.0f && direction <= 89.9f || direction >= -360.0f && direction <= -270.1f)
                        {
                            eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 90.0f)
                        {
                            eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 180.0f)
                        {
                            eHProjInstance.AddForce(bulSpawn.forward * -hprojSpeed);
                            shootTimer = 0.0f;
                        }

                        else if (direction == 270.0f)
                        {
                            eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                            shootTimer = 0.0f;
                        }
                    }*/
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(bulSpawn.position, spwnSpoint);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            beginShoot = true;
            /*if (tricksterTurret)
            {
                Rigidbody2D tProjInstance;
                tProjInstance = Instantiate(tProjectile, bulSpawn.position, bulSpawn.rotation);
                if (direction == 0.0f) //|| direction >= -360.0f && direction <= -270.1f)
                {
                    tProjInstance.AddForce(bulSpawn.forward * projSpeed);
                }

                if (direction == 180.0f) //|| direction >= -180.0f && direction <= -90.1f)
                {
                    tProjInstance.AddForce(bulSpawn.forward * -projSpeed);
                }
            }*/

            if (!tricksterTurret)
            {
                if (!hardTurret)
                {
                    Rigidbody2D eProjInstance;
                    eProjInstance = Instantiate(eProjectile, bulSpawn.position, bulSpawn.rotation);
                    if (direction == 0.0f)
                    {
                        eProjInstance.AddForce(bulSpawn.right * -projSpeed);
                    }

                    else if (direction == 90.0f)
                    {
                        eProjInstance.AddForce(bulSpawn.up * -projSpeed);
                    }

                    else if (direction == 180.0f)
                    {
                        eProjInstance.AddForce(bulSpawn.right * projSpeed);
                    }

                    else if (direction == 270.0f)
                    {
                        eProjInstance.AddForce(bulSpawn.up * projSpeed);
                    }
                }

                /*if (hardTurret)
                {
                    Rigidbody2D eHProjInstance;
                    eHProjInstance = Instantiate(eHardProjectile, bulSpawn.position, bulSpawn.rotation);
                    if (direction == 0.0f)
                    {
                        eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                    }

                    else if (direction == 90.0f)
                    {
                        eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                    }

                    else if (direction == 180.0f)
                    {
                        eHProjInstance.AddForce(bulSpawn.forward * -hprojSpeed);
                    }

                    else if (direction == 270.0f)
                    {
                        eHProjInstance.AddForce(bulSpawn.forward * hprojSpeed);
                    }
                }*/
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            beginShoot = false;
            shootTimer = 0.0f;
        }
    }

	public void KillPlayer(){
		beginShoot = false;
		shootTimer = 0.0f;
	}
}