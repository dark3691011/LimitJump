using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmrController : MonoBehaviour
{
   	public Transform Player;
	public float smoothTime=0.5f;
	Vector3 velocity = Vector3.zero;

	//for x,y min, max camera
	public bool minX,maxX,maxY,minY;
	public float xMinValue,xMaxValue,yMinValue,yMaxValue;

    // Start is called before the first frame update
    void Start()
    {
    	
    }

    // Update is called once per frame
    void LateUpdate()
    {
    	Vector3 targetPos = Player.position;

    	//for x,y max,min
    	if(minX==true && maxX==true){
    		targetPos.x = Mathf.Clamp(Player.position.x,xMinValue,xMaxValue);
    	}else if (minX==true) {
    		targetPos.x = Mathf.Clamp(Player.position.x,xMinValue,Player.position.x);
    	}else if (maxX==true) {
    		targetPos.x = Mathf.Clamp(Player.position.x,Player.position.x,xMaxValue);
    	}

    	if(minY==true && maxY==true){
    		targetPos.y = Mathf.Clamp(Player.position.y,yMinValue,yMaxValue);
    	}else if (minY==true) {
    		targetPos.y = Mathf.Clamp(Player.position.y,yMinValue,Player.position.y);
    	}else if (maxY==true) {
    		targetPos.y = Mathf.Clamp(Player.position.y,Player.position.y,yMaxValue);
    	}
    	
    	//camera following
    	targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position,targetPos,ref velocity,smoothTime);
    }
}
