using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int HP=1;
    public bool dead;
	void FixedUpdate(){
		if(isDead()){
			gameObject.SetActive(false);
		}
        dead = isDead();
	}

    void OnTriggerEnter2D(Collider2D other){
    	if(other.gameObject.tag == "Weapon"){
    		int DamageTake = other.GetComponent<Weapon>().Damage;
    		HP -=DamageTake;
    	}
    }

    public bool isDead(){
    	if(HP<=0){
    		return true;
    	} else {
    		return false;
    	}
    }
}
