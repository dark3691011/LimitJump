using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWeapon : MonoBehaviour
{
	public GameObject a;
    public GameObject b;
    public float x=0;
    public float y=0;
    bool fireA=true;


    void FixedUpdate()
    {
        float getHorizontal = Input.GetAxis("Horizontal");
        if(getHorizontal>0){
            fireA=true;
        }else if (getHorizontal<0) {
            fireA=false;
        }
    }

    void Update(){
        Vector3 tmp =transform.position;
        if(Input.GetKeyDown(KeyCode.Space)&& fireA==true){
            tmp.x +=x;
            tmp.y +=y;
            Instantiate(a, tmp, a.transform.rotation);
            gameObject.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Space)&& fireA==false) {
            tmp.x -=x;
            tmp.y -=y;
            Instantiate(b, tmp, b.transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
