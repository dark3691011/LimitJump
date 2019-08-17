using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBrick : MonoBehaviour
{
	Rigidbody2D rb;
	public float rcheck;
	private bool check;
	public LayerMask what;
	public float delayTime;
	public Transform checkPosition;

	void Start(){
		rb= GetComponent<Rigidbody2D>();
		//rb.gravityScale = 0;
	}
	void Update(){
		check = Physics2D.OverlapCircle(checkPosition.position,rcheck,what);
		if(check == true){
			rb.isKinematic = false;
			Destroy(gameObject,delayTime);
		}
	}

    /*void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Ground")){
    		Destroy(gameObject,delayTime);
    	}
    }*/
}
