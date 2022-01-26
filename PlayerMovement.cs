using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    /*public AudioSource audioSource;
    public AudioClip superJump;
    public AudioClip step;
    public AudioClip jump;
    public AudioClip dashSound;
    public AudioClip jumpLanding;*/

    [SerializeField] float bSpeed, jForce, sjForce, jHForce, wjForce, dSpeed, dLSpeed, dTime, dTimeStart, cdTimer;
	[SerializeField] bool isGrounded = false, highSpeed = false, canHighJump = false, canDJump = false, isJumping = false, jKeyDown = false, canDash = false, canWallJump, firstJump = true, bump = false;
	[SerializeField] GameObject Char, shortdashParticles, longdashParticles, highJumpParticles;
	[SerializeField] Vector3 cjForce;
	//[SerializeField] JumpBoxActive jumpBox;

    private float cdTimeOver;
	private int Direction = 0, damage;
	private Rigidbody2D CharRb;
	//private Animator AnnaIdle;
    //Animator anim;
    private bool IsRunning, IsIdle, IsJumping;
    //private GameManager gm;
    //private PlayerStuff ps;
    //private bool isPaused, hitFromRight, rightHit;
    private bool dashing;
	//private float knockbackForce, knockbackTimer, knockbackLength;
	private Vector2 adj;
    Vector3 cjForceOg;
    //public object Set { get; private set; }

    void Start(){
        CharRb = Char.GetComponent<Rigidbody2D>();
        dTime = dTimeStart;
        cjForceOg = cjForce;
        dashing = false;
    }

    //public void OnCreate(){  
		//ps = this.gameObject.GetComponent<PlayerStuff>();
		/*gm = GameManager.GM.GetComponent<GameManager>();
		audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();*/
        //isPaused = false;
        //knockbackForce = 35.0f;
		//knockbackTimer = -0.5f;
		//knockbackLength = 0.3f;
		//hitFromRight = false;	
	//}

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            CharJump();
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            jKeyDown = false;
        }
        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded && firstJump){
            canDJump = true;
            jKeyDown = false;
        }
        if (Input.GetMouseButton(1) && canDash){
            Dashing();
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.S)){
            GPound();
        }
		if (dTime <= 0 && !canDash){
		    Direction = 0;
		    canDash = true;
		}
        else if (dTime > 0){
		    dTime -= Time.deltaTime;
			if (dTime <= 1.1f && dashing){
				CharRb.velocity = Vector3.zero;
				dashing = false;
			}
		}
    }

    void FixedUpdate(){
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)){
            CharMovement();
        }
            /*if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsJumping", false);
            }*/
        if (isJumping){
                /*if (Input.GetKeyUp(KeyCode.Space))
                {
                    anim.SetBool("IsJumping", false);
                    anim.SetBool("IsIdle", true);
                    anim.SetBool("IsRunning", false);
                }*/
            if (!jKeyDown && Vector3.Dot(CharRb.velocity, Vector3.up) > 0 && !bump){
                CharRb.AddForce(cjForce * CharRb.mass);
            }
        }
		/*} else if (knockbackTimer > 0f){
			knockbackTimer -= Time.deltaTime;
			if (hitFromRight) {
				adj.x = knockbackForce;
				adj.y = knockbackForce;
				CharRb.AddForce (adj,ForceMode2D.Force);
			}
			if (!hitFromRight) {
				adj.x = -knockbackForce;
				adj.y = knockbackForce;
				CharRb.AddForce (adj,ForceMode2D.Force);
			}
			if (knockbackTimer <= 0){
				CharRb.velocity = Vector3.zero;
			}
		}*/
    }

    void GPound()
    {
        if (!isGrounded){
            Debug.Log("Works");
            CharRb.velocity = Vector3.down * dSpeed;
            Instantiate(shortdashParticles, transform.position, Quaternion.identity);
            if (isGrounded){
                CharRb.velocity = Vector3.zero;
            }
        }
    }

    void Dashing(){
		//audioSource.PlayOneShot(dashSound);
		dashing = true;
		if (Direction == 1){
			CharRb.velocity = Vector3.right * dSpeed;
			Instantiate (shortdashParticles, transform.position, Quaternion.identity);
			dTime = cdTimer;
			canDash = false;
            if (isJumping) canDash = false;
		}
		if (Direction == 2){
			CharRb.velocity = Vector3.left * dSpeed;
            Instantiate(shortdashParticles, transform.position, Quaternion.identity);
			dTime = cdTimer;
			canDash = false;
            if (isJumping) canDash = false;
        }
    }

    void CharJump(){
        if (isGrounded){
		    isGrounded = false;
            jKeyDown = true;
            /*anim.SetBool("IsJumping", true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning", false);*/
            CharRb.AddForce(Vector3.up * jForce, ForceMode2D.Impulse);
            //audioSource.PlayOneShot(jump);
            isJumping = true;
		}
        else if (canDJump){
            CharRb.velocity = Vector3.zero;
            firstJump = false;
			canDJump = false;
            jKeyDown = true;
            //anim.SetBool("IsJumping", true);
            //anim.SetBool("IsIdle", false);
            CharRb.AddForce(Vector3.up * (jForce * sjForce), ForceMode2D.Impulse);
        }
    }

    void CharMovement(){
		if (Input.GetKey (KeyCode.D)){
            /*anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);*/
			Char.transform.position += Vector3.right * bSpeed * Time.fixedDeltaTime;
            if (canDash){
                Direction = 1;
            }
		}
		if (Input.GetKey (KeyCode.A)){
            /*anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);*/
            Char.transform.position += Vector3.left * bSpeed * Time.fixedDeltaTime;
            if (canDash){
                Direction = 2;
            }
		}
    }

	void StopVelocity(){
		CharRb.velocity = Vector3.zero;
	}

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Floor"){
			firstJump = true;
			isGrounded = true;
            canDJump = false;
            isJumping = false;
            canDash = true;
            bump = false;
            cjForce = cjForceOg;
        }
        /*else if (col.gameObject.CompareTag("Enemy")){
            EnemyStuff es = col.gameObject.GetComponent<EnemyStuff>();
            damage = es.GetDamage();
			if (col.transform.position.x > this.transform.position.x) rightHit = false;
			if (col.transform.position.x < this.transform.position.x) rightHit = true;
            ps.HurtPlayer(rightHit);
        }*/
        else if (col.gameObject.tag == "Bumper"){
            cjForce = new Vector3(0, 0, 0);
            bump = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Bumper"){
            isGrounded = false;
            canDJump = true;
            isJumping = true;
            canDash = true;
        }
		if (col.gameObject.tag == "Wall"){
            canWallJump = false;
            isGrounded = false;
			CharRb.gravityScale = 1;
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "Floor"){
            isGrounded = true;
            cjForce = cjForceOg;
            bump = false;
        }
		if (col.gameObject.tag == "Wall" && isJumping && !isGrounded){
            canWallJump = true;
            if (canWallJump){
                CharRb.gravityScale = 0.3f;
				if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D)){
					CharRb.AddForce(Vector3.left * wjForce, ForceMode2D.Impulse);
					CharRb.AddForce(Vector3.up * wjForce, ForceMode2D.Impulse);
                    CharRb.gravityScale = 1;
                    canWallJump = false;
					canDJump = true;
                }
				if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A)){
					CharRb.AddForce(Vector3.right * wjForce, ForceMode2D.Impulse);
					CharRb.AddForce(Vector3.up * wjForce, ForceMode2D.Impulse);
                    CharRb.gravityScale = 1;
                    canWallJump = false;
					canDJump = true;
                }
            }
        }
    }

    public bool GetIsGrounded(){
        return isGrounded;
    }

    /*public void ChangeIsPaused(){
        isPaused = !isPaused;
    }

	public void Hit(bool hit){
		hitFromRight = hit;
		knockbackTimer = knockbackLength;
	}*/
}