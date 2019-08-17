using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spings : MonoBehaviour
{
	BoxCollider2D col;
	bool StOn;
	public Transform check;
	public float rcheck;
	public LayerMask what;

	public Animator anim;

    void FixedUpdate()
    {
    	StOn=Physics2D.OverlapCircle(check.position,rcheck,what);
    	if(StOn){
	        anim.SetBool("StOn",true);
    	} else {
	        anim.SetBool("StOn",false);
    	}
    }
}
