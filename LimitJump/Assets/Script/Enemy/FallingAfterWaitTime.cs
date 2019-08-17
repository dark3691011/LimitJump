using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingAfterWaitTime : MonoBehaviour
{
	Rigidbody2D rb;
	public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("falling",waitTime);
    }


    void falling(){
    	rb.isKinematic = false;
    }
}
