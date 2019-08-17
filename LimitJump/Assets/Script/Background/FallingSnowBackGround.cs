using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSnowBackGround : MonoBehaviour
{
	public GameObject snow;
	public Transform BackGround;
	public float minX=0.0f;
	public float maxX=0.0f;
	public float minY=0.0f;
	public float maxY=0.0f;
	public float waitingTime=0.5f;
	float wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = waitingTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	Vector3 tmp= BackGround.position;
    	tmp.y += Random.Range(minY,maxY);
    	tmp.x+=Random.Range(minX,maxX);
    	if(wait<=0){
        	Instantiate(snow,tmp,snow.transform.rotation);
        	wait= waitingTime;
    	} else {
    		wait-= Time.deltaTime;
    	}
    }
}
