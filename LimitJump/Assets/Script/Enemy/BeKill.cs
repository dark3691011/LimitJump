using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeKill : MonoBehaviour
{
	public GameObject efect;
    void OnTriggerEnter2D(Collider2D a){
    	if(a.CompareTag("Weapon")){
    		Destroy(gameObject);
    		Instantiate(efect,transform.position,efect.transform.rotation);
    	}
    }
}
