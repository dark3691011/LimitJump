using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBox : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed;

    public float where;
    public float where2;
    bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingRight && transform.position.x>where){
            movingRight = false;
        } else if (movingRight==false && transform.position.x<where2) {
            movingRight = true;
        }
        //Invoke("move",5f);

        if(movingRight){
            rb.velocity = Vector2.right * speed;
        } else {
            rb.velocity = Vector2.right * -1 * speed;
        }
    }


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
           other.collider.transform.SetParent(transform);
           //other.collider.transform.localPosition = transform.position;
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
           other.collider.transform.SetParent(null);
        }
    }
}
