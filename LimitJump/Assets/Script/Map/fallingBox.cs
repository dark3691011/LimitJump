using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBox : MonoBehaviour
{
	Rigidbody2D rb;

	public float delayF;
	public float delayD;

	bool playerIsOn;
	public Transform check;
	public float rcheck;
	public LayerMask whatIs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerIsOn = Physics2D.OverlapCircle(check.position,rcheck,whatIs);
        if(playerIsOn){
        	Invoke("fall",delayF);
        	Destroy(gameObject,delayD+delayF);
        }
    }

    void fall(){
    	rb.isKinematic = false;
    }
}
