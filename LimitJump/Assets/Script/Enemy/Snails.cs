using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snails : MonoBehaviour
{
	public float speed;

	public Transform groundCheck;
	public float rCheck;
	private bool facingRight=true;


    // Update is called once per frame
    void Update()
    {
    	transform.Translate(Vector2.right*speed*Time.deltaTime);

        RaycastHit2D groundInfo=Physics2D.Raycast(groundCheck.position,Vector2.down,rCheck);
        if(groundInfo.collider==false){
        	if(facingRight==true){
        		transform.eulerAngles = new Vector3(0,-180,0);
        		facingRight=false;
        	}else{
        		transform.eulerAngles = new Vector3(0,0,0);
        		facingRight=true;
        	}
        }
    }
}
