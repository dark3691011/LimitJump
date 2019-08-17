using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    int levelReached;
    void Start(){
    	levelReached = PlayerPrefs.GetInt("levelReached",1);
    }
    public void LoadS(){
    	SceneManager.LoadScene(levelReached);
    }
}
