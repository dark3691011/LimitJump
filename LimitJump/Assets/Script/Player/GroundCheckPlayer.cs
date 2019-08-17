using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckPlayer : MonoBehaviour
{
	public GameObject dustCloud;

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Ground")){
			Instantiate(dustCloud,transform.position,dustCloud.transform.rotation);
		}
	}
}
