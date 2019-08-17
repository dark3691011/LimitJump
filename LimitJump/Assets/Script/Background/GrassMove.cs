using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMove : MonoBehaviour
{
	public Animator anim;
	public float time = 1.5f;
	float waiting;
    // Start is called before the first frame update
    void Start(){
    	waiting=0f;
    }
    void FixedUpdate(){
    	if(waiting>0){
    		waiting+=Time.deltaTime;
    	}
    	if(waiting>=time){
    		anim.SetBool("Move",false);
    	}
    }
    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player")){
    		anim.SetBool("Move",true);
    		waiting = 0.1f;
    	}
    }
}
