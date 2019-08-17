using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed=10;
    public float timeFalling=2f;
    public float timeFall;
    public Animator anim;

    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        timeFall = timeFalling;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeFall>=0){
            Fly();
        }else if (timeFall<0) {
            Fall();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Ground"){
            Fall();
        }
    }


    void Fly(){
        anim.SetBool("isStanding",false);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        timeFall -= Time.deltaTime;
    }

    void Fall(){
        anim.SetBool("isStanding",true);
        rb.velocity = new Vector2(0,rb.velocity.y);
        rb.isKinematic = false;
        col.isTrigger = false;
        transform.gameObject.tag="Weapon1";
    }
}
