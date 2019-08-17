using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeWeapon : MonoBehaviour
{
	public GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
    	if(other.gameObject.tag == "Weapon1"){
    		Weapon.SetActive(true);
    	}
    }
}
