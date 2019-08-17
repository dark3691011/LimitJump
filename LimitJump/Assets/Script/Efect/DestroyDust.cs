using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDust : MonoBehaviour
{
	public float delayTime=0.5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject,delayTime);
    }
}
