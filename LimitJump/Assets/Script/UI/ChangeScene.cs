using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public int sceneLoad;
    public void loadS(){
    	SceneManager.LoadScene(sceneLoad);
    }
}
