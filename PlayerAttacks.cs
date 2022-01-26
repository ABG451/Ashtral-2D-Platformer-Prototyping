using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

    //[SerializeField] AudioSource audioS;
    //[SerializeField] AudioClip missileSound; ,basicProjSound, teleportProjSound, sensorBombSound, chargeShotSound, meleeSound;
    [SerializeField] float startAttackCD, attackRange, projectileSpeed = 750, mprojectileSpeed = 250, csTime;
    [SerializeField] Transform attackPosRight, attackPosLeft; // downAttackPosition, upAttackPosition;
	[SerializeField] LayerMask isEnemy;
	[SerializeField] int damage;
	[SerializeField] GameObject Player;
	[SerializeField] Rigidbody2D bProjectile, mProjectile, tProjectile, sBomb, csProjectile;

    private float csTimeDone;
    //Uncomment Lines 22, 31, 80, part of 77
    public static string weaponType;
	//Animator AnnaStandAttacking;
	Transform attackPosition;
	private DamageEnemy damEnemy;
	//private WeaponsManager wm;
	//private TeleProjectile tp;
	private float attackCD;

	// Use this for initialization
	void Start () {
        //AnnaStandAttacking = Player.GetComponent<Animator>();
        attackPosition = attackPosRight;
		weaponType = "missile projectile";
		//wm = GameManager.GM.GetComponent<WeaponsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Alpha1)) {
			weaponType = "melee";
			wm.SetWeapon (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			weaponType = "basic projectile";
			wm.SetWeapon (2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			weaponType = "missile projectile";
			wm.SetWeapon (3);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			weaponType = "teleportation";
			wm.SetWeapon (4);
		}*/
		if (Input.GetKeyDown(KeyCode.A)) attackPosition = attackPosLeft;
		if (Input.GetKeyDown(KeyCode.D))  attackPosition = attackPosRight;
		//if (Input.GetKeyDown(KeyCode.S)) attackPosition = downAttackPosition;
		//if (Input.GetKeyDown(KeyCode.W)) attackPosition = upAttackPosition;

        //Debug.Log(weaponType);

		/*if (weaponType == "basic projectile"){
			if (Input.GetMouseButtonDown(0) && wm.CanBasic ()){
				Rigidbody2D projInstance;
                projInstance = Instantiate(bProjectile, attackPosition.position, attackPosition.rotation);
				wm.AddBasic (projInstance.gameObject);
                audioS.PlayOneShot(basicProjSound);
                AnnaStandAttacking.SetBool("IsStandAttacking", true);

                if (attackPosition == attackPosRight) projInstance.AddForce(attackPosition.right * projectileSpeed);
                if (attackPosition == attackPosLeft) projInstance.AddForce(attackPosition.right * -projectileSpeed);
                if (attackPosition == upAttackPosition) projInstance.AddForce(attackPosition.up * projectileSpeed);
                if (attackPosition == downAttackPosition) projInstance.AddForce(attackPosition.up * -projectileSpeed);
            } else{
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
            }
        }*/
        //Standing Attack
        if (weaponType == "missile projectile"){
			if (Input.GetMouseButtonDown(0))  /*&& wm.CanMissile (this.gameObject)*/
            {
                Rigidbody2D missProjInstance;
                missProjInstance = Instantiate(mProjectile, attackPosition.position, attackPosition.rotation);
				//wm.AddMissile (missProjInstance.gameObject);
                //AnnaStandAttacking.SetBool("IsStandAttacking", true);
                //AnnaStandAttacking.SetBool("IsRunningAttack", false);
                //audioS.PlayOneShot(missileSound);
                
                if (attackPosition == attackPosRight) missProjInstance.AddForce(attackPosition.right * projectileSpeed);
                if (attackPosition == attackPosLeft) missProjInstance.AddForce(attackPosition.right * -projectileSpeed);
                //if (attackPosition == upAttackPosition) missProjInstance.AddForce(attackPosition.up * projectileSpeed);
                //if (attackPosition == downAttackPosition) missProjInstance.AddForce(attackPosition.up * -projectileSpeed);
            } else{
                //AnnaStandAttacking.SetBool("IsStandAttacking", false);
                //AnnaStandAttacking.SetBool("IsRunningAttack", false);
            }
		}
        //Running Attack 
       /*if (weaponType == "missile projectile" && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            
            if (Input.GetMouseButtonDown(0) && wm.CanMissile() && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
            {
                Rigidbody2D missProjInstance;
                missProjInstance = Instantiate(mProjectile, attackPosition.position, attackPosition.rotation);
                wm.AddMissile(missProjInstance.gameObject);
                AnnaStandAttacking.SetBool("IsRunningAttack", true);
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
                //audioS.PlayOneShot(missileSound);

                if (attackPosition == attackPosRight) missProjInstance.AddForce(attackPosition.right * projectileSpeed);
                if (attackPosition == attackPosLeft) missProjInstance.AddForce(attackPosition.right * -projectileSpeed);
                if (attackPosition == upAttackPosition) missProjInstance.AddForce(attackPosition.up * projectileSpeed);
                if (attackPosition == downAttackPosition) missProjInstance.AddForce(attackPosition.up * -projectileSpeed);
                Debug.Log("RunningShotWorks");
            }
            else
            {
                AnnaStandAttacking.SetBool("IsRunningAttack", false);
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
            }
        }/*

        /*if (weaponType == "sensor bomb"){
			if (Input.GetMouseButton(0) && wm.CanSmart ()){
                Rigidbody2D sBombInstance;
                sBombInstance = Instantiate(sBomb, attackPosition.position, attackPosition.rotation);
				wm.AddSmart (sBombInstance.gameObject);
				audioS.PlayOneShot(sensorBombSound);
                AnnaStandAttacking.SetBool("IsStandAttacking", true);
            } else{
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
            }
		}

        if (weaponType == "charge shot")
        {         
            if (Time.time > csTimeDone)
            {
                if (Input.GetMouseButton(0))
                {
                    csTimeDone = Time.time;
                    Debug.Log("Charging");
                    Debug.Log(csTimeDone + "Time till charge over" + "  VS  " + Time.time);

                    Rigidbody2D csProjectileInstance;
                    csProjectileInstance = Instantiate(csProjectile, attackPosition.position, attackPosition.rotation);
                    Debug.Log("Fire");
                    if (attackPosition == attackPosRight) csProjectileInstance.AddForce(attackPosition.right * projectileSpeed);
                    if (attackPosition == attackPosLeft) csProjectileInstance.AddForce(attackPosition.right * -projectileSpeed);
                    //if (attackPosition == upAttackPosition) csProjectileInstance.AddForce(attackPosition.up * projectileSpeed);
                    //if (attackPosition == downAttackPosition) csProjectileInstance.AddForce(attackPosition.up * -projectileSpeed);

                    if (Input.GetMouseButtonUp(0))
                    {
                        csTimeDone = Time.time + csTime;
                    }
                }              
            }
        }

        if (weaponType == "teleportation"){
			if (Input.GetMouseButtonDown(0) && wm.CanTele ()){
                Rigidbody2D tProjInstance;
                tProjInstance = Instantiate(tProjectile, attackPosition.position, attackPosition.rotation);
				wm.AddTele (tProjInstance.gameObject);
				tp = tProjInstance.GetComponent<TeleProjectile> ();
				tp.OnCreate (this.gameObject);
				audioS.PlayOneShot(teleportProjSound);
                AnnaStandAttacking.SetBool("IsStandAttacking", true);

                if (attackPosition == attackPosRight) tProjInstance.AddForce(attackPosition.right * projectileSpeed);
                if (attackPosition == attackPosLeft) tProjInstance.AddForce(attackPosition.right * -projectileSpeed);
                if (attackPosition == upAttackPosition) tProjInstance.AddForce(attackPosition.up * projectileSpeed);
                if (attackPosition == downAttackPosition) tProjInstance.AddForce(attackPosition.up * -projectileSpeed);
            } else{
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
            }
		}

        if (weaponType == "melee"){
            if (attackCD <= 0){
                if (Input.GetMouseButtonDown(0)){
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, isEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++){
						enemiesToDamage[i].GetComponent<EnemyStuff>().HurtEnemy(damage,this.tag);
                        audioS.PlayOneShot(meleeSound);
                    }
                    AnnaStandAttacking.SetBool("IsStandAttacking", true);
                    attackCD = startAttackCD;
                }
            } else {
                attackCD -= Time.deltaTime;
                AnnaStandAttacking.SetBool("IsStandAttacking", false);
            }
        }*/
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosRight.position, attackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosLeft.position, attackRange);

        /*Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(downAttackPosition.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(upAttackPosition.position, attackRange);*/

    }
}