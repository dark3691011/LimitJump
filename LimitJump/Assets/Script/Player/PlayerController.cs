using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;

	//Some var for run and animation
	public float speed;
	bool facingRight=true;
	public Animator anim;
    //public GameObject DustCloud;

	//for die
	public bool dieIfFalling;
	public float diePosition;
    public bool dead;
    public bool completed;

	//var for jump
	public float jumpForce;
	public int jumpValue;
	private bool isJumping=false;// for anim
	private bool isGround;
	public Transform groundCheck;
	public float rCheck;
	public LayerMask whatIsGround;
    public int extraJumpValue;
    private int extraJump;


    // Start is called before the first frame update
    void Start()
    {
    	//get Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //Jump
        extraJump = extraJumpValue;
    }

    void FixedUpdate()
    {
    	//for run
        float getHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(getHorizontal*speed, rb.velocity.y);
        anim.SetFloat("Run",Mathf.Abs(getHorizontal));

        //Character facing
        if(facingRight==true && getHorizontal<0){
        	Flip();
        } else if (facingRight==false && getHorizontal>0) {
        	Flip();
        }


        //for falling die
        if(dieIfFalling==true){
        	Vector2 tmpPosition = transform.position;
	        if(tmpPosition.y < diePosition){
	        	dead=true;
	        }
    	}
    }
    void Update(){
    	//for jump
        isGround=Physics2D.OverlapCircle(groundCheck.position,rCheck,whatIsGround);
        if(isGround){
        	isJumping=false;
            extraJump = extraJumpValue;
        }else {
        	isJumping=true;
        }
        anim.SetBool("isJumping",isJumping);
        if(Input.GetKeyDown(KeyCode.UpArrow) && jumpValue>0 && extraJump>0){
            rb.velocity = Vector2.up * jumpForce;
            jumpValue--;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump==0 && isGround==true  && jumpValue>0) {
            rb.velocity = Vector2.up * jumpForce;
            jumpValue--;
        }
    }


    // complete or die
    void OnCollisionEnter2D(Collision2D other){
    	if(other.gameObject.tag == "Enemy"){
    		dead=true;
            gameObject.SetActive(false);
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Door")){
    		completed=true;
    		gameObject.SetActive(false);
    	}
    	if(other.gameObject.tag == "Enemy"){
    		dead=true;
            gameObject.SetActive(false);
    	}
    }
    void Flip(){
    	facingRight = !facingRight;
    	Vector3 Scaler= transform.localScale;
    	Scaler.x *=-1;
    	transform.localScale = Scaler;
    }
}
