using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGhost : MonoBehaviour
{
    //for normal move
	public float speed;
	public float maxX,minX;
	public float jumpForce;

    //time for run and jump
	public float waitingtimeValue;
	public float waitingtime;
    public float timeJump=0.5f;

    //End game
    public GameObject Door;

    //for move right or left
	public bool facingRight;
	Rigidbody2D rb;

    //for gear
    public GameObject[] HP;
    public GameObject[] Body;
    int gear;
    float speed2;
    float speed1;
    float gravity2;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        waitingtime =waitingtimeValue;
        HP[0].SetActive(true);
        HP[1].SetActive(false);
        HP[2].SetActive(false);

        //second gear
        speed2 = speed*3;
        speed1 = speed*1.25f;
        gravity2 = rb.gravityScale*3;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Gear
        if(HP[0].GetComponent<Enemy>().isDead() == false){
            gear =1;
        } else if(HP[0].GetComponent<Enemy>().isDead() && HP[1].GetComponent<Enemy>().isDead()==false){
            HP[1].SetActive(true);
            gear = 2;
        } else if (HP[1].GetComponent<Enemy>().isDead() && HP[2].GetComponent<Enemy>().isDead()==false) {
            HP[2].SetActive(true);
            gear = 3;
        } else if (HP[2].GetComponent<Enemy>().isDead()) {
            gear = 4;
        }

        //active gear
        switch (gear)
        {
            case 1:
                Gear1();
                break;
            case 2:
                Gear2();
                break;
            case 3:
                Gear3();
                break;
            case 4:
                Door.SetActive(true);
                Destroy(gameObject);
                break;
        }
    }




    void Gear1(){
        float pos = transform.position.x;
        if(facingRight && pos>=maxX){
            facingRight=false;
        } else if (!facingRight && pos<=minX) {
            facingRight=true;
        }

        if(facingRight && waitingtime<waitingtimeValue - timeJump){
            rb.velocity=Vector2.right *speed;
        } else if(!facingRight && waitingtime<waitingtimeValue -timeJump){
            rb.velocity=Vector2.right*speed*-1;
        }

        if(waitingtime<=0){
            rb.velocity = Vector2.zero;
            rb.velocity = Vector2.up * jumpForce;
            waitingtime =waitingtimeValue;
        }
        waitingtime-=Time.deltaTime;
    }


    void Gear2(){
        speed = speed2;
        rb.gravityScale = gravity2;
        Body[0].SetActive(false);
        Gear1();
    }

    void Gear3(){
        Body[1].SetActive(false);
        speed = speed1;
        rb.isKinematic = true;
        rb.velocity= Vector2.zero;
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed* Time.deltaTime);
    }
}
